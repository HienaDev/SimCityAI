using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckForAccident : MonoBehaviour
{

    public bool Accident { get; private set; }

    [SerializeField] private float timeInAccident = 5;
    private WaitForSeconds wfs;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        Accident = false;
        wfs = new WaitForSeconds(timeInAccident);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Pedestrian"))
        {
            if (collision.gameObject.CompareTag("Pedestrian"))
            {
                collision.gameObject.GetComponent<PedestrianController>().HasAccident = true;
            }
            StartCoroutine(StartAccident());
        }
            
    }

    private IEnumerator StartAccident()
    {
        Debug.Log("ACCIDENT");
        navMeshAgent.speed = 0;
        Accident = true;
        yield return wfs;
        Accident = false;
    }

}
