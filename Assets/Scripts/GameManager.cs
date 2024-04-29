using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("[PEDESTRIANS]")]
    [SerializeField] private GameObject     pedestrianPrefab;
    [SerializeField] private int            maxNumberOfPedestrians = 10;
    [SerializeField] private GameObject[]   pedestriansSpawnPoints;
    [SerializeField] private float          maxDestinyTimePedestrians = 10.0f;

    [Header("[CAOS]")]
    [SerializeField] [Range(0, 100)] private float          caosChange = 2f;
    [SerializeField] private float          maxCaosTime = 10.0f;
    [SerializeField] private float          blinkSpeed = 5;

    private int numberOfPedestrians = 0;

    public static GameManager Instance { get; private set; }
    public float GetMaxDestinyTimePedestrians => maxDestinyTimePedestrians;
    public float GetMaxCaosTime => maxCaosTime;
    public float GetBlinkSpeed => blinkSpeed;
    public float GetCaosChange => caosChange;

    private void Awake()
    {
        for (int i = 0; i < maxNumberOfPedestrians; i++)
        {
            StartCoroutine(SpawnPedestrianAtRandomTime());
        }

        Instance = this;
    }

    private IEnumerator SpawnPedestrianAtRandomTime()
    {
        float waitTime = Random.Range(0f, maxDestinyTimePedestrians);
        yield return new WaitForSeconds(waitTime);

        int spawnPointIndex = Random.Range(0, pedestriansSpawnPoints.Length);
        GameObject spawnPoint = pedestriansSpawnPoints[spawnPointIndex];
        Instantiate(pedestrianPrefab, spawnPoint.transform.position, Quaternion.identity);
        numberOfPedestrians++;
    }

    public void AddPedestrian()
    {
        numberOfPedestrians++;
    }

    public void RemovePedestrian()
    {
        numberOfPedestrians--;
    }
}