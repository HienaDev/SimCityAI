using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPedestrianCollision : MonoBehaviour
{
    public bool PedestrianCollision {  get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        PedestrianCollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = true;
    }

    
}
