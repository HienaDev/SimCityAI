using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("[PEDESTRIANS]")]
    [SerializeField] private GameObject   pedestrianPrefab;
    [SerializeField] private int          maxNumberOfPedestrians = 10;
    [SerializeField] private GameObject[] pedestriansSpawnPoints;
    [SerializeField] private float        maxDestinyTimePedestrians = 10.0f;

    [Header("[CAOS]")]
    [SerializeField] [Range(0, 100)] private float caosChance = 2f;
    [SerializeField] private float                 maxCaosTime = 10.0f;
    [SerializeField] private float                 blinkSpeed = 5;

    private int numberOfPedestrians = 0;

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
    /// Get the max time that an agent can be in caos state
    /// </summary>
    public float GetMaxCaosTime => maxCaosTime;
    /// <summary>
    /// Get the speed of the blink effect
    /// </summary>
    public float GetBlinkSpeed => blinkSpeed;
    /// <summary>
    /// Get the chance of an agent starting the caos
    /// </summary>
    public float GetCaosChance => caosChance;

    /// <summary>
    /// Start the game manager
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < maxNumberOfPedestrians; i++)
        {
            StartCoroutine(SpawnPedestrianAtRandomTime());
        }

        Instance = this;
    }

    /// <summary>
    /// Spawn a pedestrian at a random time in a random spawn point
    /// </summary>
    /// <returns> Wait time </returns>
    private IEnumerator SpawnPedestrianAtRandomTime()
    {
        float waitTime = Random.Range(0f, maxDestinyTimePedestrians);
        yield return new WaitForSeconds(waitTime);

        int spawnPointIndex = Random.Range(0, pedestriansSpawnPoints.Length);
        GameObject spawnPoint = pedestriansSpawnPoints[spawnPointIndex];
        Instantiate(pedestrianPrefab, spawnPoint.transform.position, Quaternion.identity);
        numberOfPedestrians++;
    }

    /// <summary>
    /// Add a pedestrian to the count
    /// </summary>
    public void AddPedestrian()
    {
        numberOfPedestrians++;
    }

    /// <summary>
    /// Remove a pedestrian from the count
    /// </summary>
    public void RemovePedestrian()
    {
        numberOfPedestrians--;
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
    }
}