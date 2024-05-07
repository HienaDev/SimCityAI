using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Check if the car is in an accident
/// </summary>
public class CheckForAccident : MonoBehaviour
{
    [SerializeField] private float timeInAccident = 5;

    private WaitForSeconds wfs;
    private NavMeshAgent   navMeshAgent;

    /// <summary>
    /// If the car is in an accident
    /// </summary>
    /// <value> The car is or not in an accident </value>
    public bool Accident { get; private set; }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Accident = false;
        wfs = new WaitForSeconds(timeInAccident);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// If a car collies with a car or pedestrian it stops moving for some time
    /// </summary>
    /// <param name="collision"></param>
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

    /// <summary>
    /// Start the accident
    /// </summary>
    /// <returns> Wait for seconds </returns>
    private IEnumerator StartAccident()
    {
        navMeshAgent.speed = 0;
        Accident = true;
        yield return wfs;
        Accident = false;
    }
}
