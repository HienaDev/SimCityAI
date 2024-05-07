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

    /// <summary>
    /// If we are no longer colliding with a pedestrian the boolean changes so that the car can move
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = false;
    }

    /// <summary>
    /// If we are colliding with a pedestrian the boolean changes so that the car stops moving
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = true;
    }

    
}
