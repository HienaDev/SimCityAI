using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("[PEDESTRIANS]")]
    [SerializeField] private GameObject     pedestrianPrefab;
    [SerializeField] private int            numberOfPedestrians = 10;
    [SerializeField] private GameObject[]   pedestriansSpawnPoints;
    [SerializeField] private float          maxDestinyTimePedestrians = 10.0f;

    [Header("[CHAOS]")]
    [SerializeField] [Range(0, 100)] private float chaosChance = 2f;
    [SerializeField] private float                 maxChaosTime = 10.0f;
    [SerializeField] private float                 blinkSpeed = 5;

    [Header("[ACCIDENT]")]
    [SerializeField] private float maxAccidentTime;

    [Header("[CARS]")]
    [SerializeField] private GameObject[] waypoints;
    private int[] carsToSpawnInEachWaypoint;
    [SerializeField] private List<IsCarDrunk> carsToGetDrunks;
    [SerializeField] private float carsToSpawn;
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private float timeForCarToSpawn;
    private WaitForSeconds wfsCar;
    [SerializeField] private Vector2 timeForCarsToMove;
    
    public GameObject[] Waypoints { get; private set; }

    private int numberOfActivePedestrians = 0;

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
    /// Start the game manager
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < numberOfPedestrians; i++)
        {
            StartCoroutine(SpawnPedestrianAtRandomTime());
        }

        Instance = this;

        
    }

    private void Start()
    {
        carsToSpawnInEachWaypoint = new int[waypoints.Length];

        carsToGetDrunks = new List<IsCarDrunk>();

        for (int i = 0; i < carsToSpawn; i++)
        {
            int waypointToSpawn = UnityEngine.Random.Range(0, waypoints.Length);
            carsToSpawnInEachWaypoint[waypointToSpawn]++;

        }

        wfsCar = new WaitForSeconds(timeForCarToSpawn);


        for (int i = 0; i < waypoints.Length; i++)
        {
            StartCoroutine(SpawnCarsAtWaypoints(i));

        }

        //RandomCarDrunk();
    }



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

    private IEnumerator SpawnCarsAtWaypoints(int n)
    {
        while (carsToSpawnInEachWaypoint[n] > 0)
        {
            carsToSpawnInEachWaypoint[n]--;
            GameObject car =  Instantiate(carPrefab, waypoints[n].transform.position, Quaternion.identity, transform);
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
        Instantiate(pedestrianPrefab, spawnPoint.transform.position, Quaternion.identity);
        numberOfActivePedestrians++;
    }

    /// <summary>
    /// Add a pedestrian to the count
    /// </summary>
    public void AddPedestrian()
    {
        numberOfActivePedestrians++;
    }

    /// <summary>
    /// Remove a pedestrian from the count
    /// </summary>
    public void RemovePedestrian()
    {
        numberOfActivePedestrians--;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Pedestrian"))
                {
                    PedestrianController pedestrianController = hit.collider.GetComponent<PedestrianController>();
                    pedestrianController.SetDrunkState(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomCarDrunk();
        }
    }
}