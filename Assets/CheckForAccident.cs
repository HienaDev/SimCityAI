using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAccident : MonoBehaviour
{

    public bool Accident { get; private set; }

    [SerializeField] private float timeInAccident = 5;
    private WaitForSeconds wfs;

    // Start is called before the first frame update
    void Start()
    {
        Accident = false;
        wfs = new WaitForSeconds(timeInAccident);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Pedestrian"))
            StartCoroutine(StartAccident());
    }

    private IEnumerator StartAccident()
    {
        Debug.Log("ACCIDENT");
        Accident = true;
        yield return wfs;
        Accident = false;
    }

}
