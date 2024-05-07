using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// When a car leaves a stop sign it goes back to having to stop on stop signs, so it only stops once per sign
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject);
        StopSignLogic ssl = other.gameObject.GetComponent<StopSignLogic>();
        if (ssl != null)
        {
            ssl.shouldStop = true;
        }
    }
}
