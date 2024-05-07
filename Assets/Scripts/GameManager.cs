using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("[PEDESTRIANS]")]
    [SerializeField] private GameObject   pedestrianPrefab;
    [SerializeField] private int          numberOfPedestrians = 10;
    [SerializeField] private GameObject[] pedestriansSpawnPoints;
    [SerializeField] private float        maxDestinyTimePedestrians = 10.0f;

    [Header("[CARS]")]
    [SerializeField] private GameObject[] carPrefabs;
    [SerializeField] private float        numberOfCars;
    [SerializeField] private GameObject[] carSpawnPoints;
    [SerializeField] private float        timeForCarToSpawn;

    [Header("[CHAOS]")]
    [SerializeField] [Range(0, 100)] private float chaosChance = 2f;
    [SerializeField] private float                 maxChaosTime = 10.0f;
    [SerializeField] private float                 blinkSpeed = 5;

    [Header("[ACCIDENT]")]
    [SerializeField] private float maxAccidentTime;

    [Header("[UI]")]
    [SerializeField] private TextMeshProUGUI carsText;
    [SerializeField] private TextMeshProUGUI pedestriansText;

    private int[]                      numberOfCarsInEachWaypoint;
    private List<IsCarDrunk>           carsToGetDrunks;
    private WaitForSeconds             wfsCar;
    private int                        numberOfActivePedestrians;
    private int                        numberOfActiveCars;
    private List<PedestrianController> spawnedPedestrians;

    /// <summary>
    /// Singleton instance
    /// </summary>
    /// <value> Game Manager </value>
    public static GameManager Instance { get; private set; }
    /// <summary>
    /// Get the max number that the pedestrians can be at the destination
    /// </summary>
    public float GetMaxDestinyTimePedestrians => maxDestinyTimePedestrians;
    /// <summary>
    /// Get the max time that an agent can be in chaos state
    /// </summary>
    public float GetMaxChaosTime => maxChaosTime;
    /// <summary>
    /// Get the speed of the blink effect
    /// </summary>
    public float GetBlinkSpeed => blinkSpeed;
    /// <summary>
    /// Get the chance of an agent starting the chaos
    /// </summary>
    public float GetChaosChance => chaosChance;
    /// <summary>
    /// Get the max time that an agent can be in accident state
    /// </summary>
    public float GetMaxAccidentTime => maxAccidentTime;
    /// <summary>
    /// Get the waypoints of the pedestrians
    /// </summary>
    public GameObject[] PedestriansWaypoints => pedestriansSpawnPoints;
    /// <summary>
    /// Get the waypoints of the cars
    /// </summary>
    public GameObject[] CarWaypoints => carSpawnPoints;

    /// <summary>
    /// Start the game manager
    /// </summary>
    private void Awake()
    {
        numberOfActivePedestrians = 0;
        numberOfActiveCars = 0;
        
        Instance = this;
    }

    /// <summary>
    /// Start spawning pedestrians and cars
    /// </summary>
    public void StartSimulation()
    {
        carsToGetDrunks = new List<IsCarDrunk>();
        spawnedPedestrians = new List<PedestrianController>();
        numberOfCarsInEachWaypoint = new int[carSpawnPoints.Length];

        for (int i = 0; i < numberOfPedestrians; i++)
        {
            StartCoroutine(SpawnPedestrianAtRandomTime());
        }

        for (int i = 0; i < numberOfCars; i++)
        {
            int waypointToSpawn = UnityEngine.Random.Range(0, carSpawnPoints.Length);
            numberOfCarsInEachWaypoint[waypointToSpawn]++;

        }

        wfsCar = new WaitForSeconds(timeForCarToSpawn);

        for (int i = 0; i < carSpawnPoints.Length; i++)
        {
            StartCoroutine(SpawnCarsAtWaypoints(i));

        }
    }

    /// <summary>
    /// Remove all cars and pedestrians
    /// </summary>
    public void ResetSimulation()
    {
        foreach(var car in carsToGetDrunks)
        {
            Destroy(car.gameObject);
        }

        foreach(var pedestrian in spawnedPedestrians)
        {
            Destroy(pedestrian.gameObject);
        }

        StopCoroutine(SpawnPedestrianAtRandomTime());

        carsToGetDrunks = new List<IsCarDrunk>();

        spawnedPedestrians = new List<PedestrianController>();

        numberOfActivePedestrians = 0;
        numberOfActiveCars = 0;

        pedestriansText.text = $"Number of pedestrians: {numberOfActivePedestrians}";
        carsText.text = $"Number of cars: {numberOfActiveCars}";
    }

    /// <summary>
    /// Get a random car drunk
    /// </summary>
    public void RandomCarDrunk()
    {
        bool alreadyDrunk = false;
        System.Random r = new System.Random();
        foreach (int i in Enumerable.Range(0, carsToGetDrunks.Count).OrderBy(x => r.Next()))
        {
            if(!alreadyDrunk && !carsToGetDrunks[i].isDrunk) 
            {
                carsToGetDrunks[i].ActivateDrunk();
                alreadyDrunk = true;
            }
        }
    }

    /// <summary>
    /// Get a random pedestrian drunk
    /// </summary>
    public void RandomPedestrianDrunk()
    {
        bool alreadyDrunk = false;
        System.Random r = new System.Random();
        foreach (int i in Enumerable.Range(0, spawnedPedestrians.Count).OrderBy(x => r.Next()))
        {
            if (!alreadyDrunk && !spawnedPedestrians[i].IsDrunk)
            {
                spawnedPedestrians[i].SetDrunkState(true);
                alreadyDrunk = true;
            }
        }
    }

    /// <summary>
    /// Spawn cars at random locations
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private IEnumerator SpawnCarsAtWaypoints(int n)
    {
        while (numberOfCarsInEachWaypoint[n] > 0)
        {
            numberOfCarsInEachWaypoint[n]--;
            GameObject car = Instantiate(carPrefabs[UnityEngine.Random.Range(0, carPrefabs.Length)], 
                                        carSpawnPoints[n].transform.position, 
                                        Quaternion.identity, 
                                        transform);
            carsToGetDrunks.Add(car.GetComponent<IsCarDrunk>());
            yield return wfsCar;
        }
    }

    /// <summary>
    /// Spawn a pedestrian at a random time in a random spawn point
    /// </summary>
    /// <returns> Wait time </returns>
    private IEnumerator SpawnPedestrianAtRandomTime()
    {
        float waitTime = UnityEngine.Random.Range(0f, maxDestinyTimePedestrians);
        yield return new WaitForSeconds(waitTime);

        int spawnPointIndex = UnityEngine.Random.Range(0, pedestriansSpawnPoints.Length);
        GameObject spawnPoint = pedestriansSpawnPoints[spawnPointIndex];
        GameObject pedestrian = Instantiate(pedestrianPrefab, 
                                            spawnPoint.transform.position, 
                                            Quaternion.identity, 
                                            transform);
        pedestrian.GetComponentInChildren<Renderer>().material = new Material(pedestrian.GetComponentInChildren<Renderer>().material);
        pedestrian.GetComponentInChildren<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        AddPedestrian();
        spawnedPedestrians.Add(pedestrian.GetComponent<PedestrianController>());
    }

    /// <summary>
    /// Add a pedestrian to the count
    /// </summary>
    public void AddPedestrian()
    {
        
        numberOfActivePedestrians++;
        pedestriansText.text = $"Number of pedestrians: {numberOfActivePedestrians}";
    }

    /// <summary>
    /// Remove a pedestrian from the count
    /// </summary>
    public void RemovePedestrian()
    {
        numberOfActivePedestrians--;
        pedestriansText.text = $"Number of pedestrians: {numberOfActivePedestrians}";
    }

    /// <summary>
    /// Add a car to the count
    /// </summary>
    public void AddCar()
    {

        numberOfActiveCars++;
        carsText.text = $"Number of cars: {numberOfActiveCars}";
    }

    /// <summary>
    /// Remove a car from the count
    /// </summary>
    public void RemoveCar()
    {
        numberOfActiveCars--;
        carsText.text = $"Number of cars: {numberOfActiveCars}";
    }
}