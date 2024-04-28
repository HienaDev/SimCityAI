using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject     pedestrianPrefab;
    [SerializeField] private int            maxNumberOfPedestrians = 10;
    [SerializeField] private GameObject[]   pedestriansSpawnPoints;
    [SerializeField] private float          maxDestinyTimePedestrians = 10.0f;

    private int numberOfPedestrians = 0;

    private void Start()
    {
        for (int i = 0; i < maxNumberOfPedestrians; i++)
        {
            StartCoroutine(SpawnPedestrianAtRandomTime());
        }
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
    
    public float GetMaxTime()
    {
        return maxDestinyTimePedestrians;
    }

    private void Update() 
    {
        Debug.Log("Number of pedestrians: " + numberOfPedestrians);
    }
}