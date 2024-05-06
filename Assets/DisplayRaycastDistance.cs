using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayRaycastDistance : MonoBehaviour
{
    [SerializeField] private float distance;
    public bool collision;
    public GameObject collisionObject;
    // Start is called before the first frame update
    void Start()
    {
        collisionObject = null;
    }

    // Update is called once per frame
    void Update()
    {

 


    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Lane"))
        {
            collision = true;
            collisionObject = other.gameObject;
            Debug.Log(other.gameObject.name);
        }
            
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
       
            
            Debug.Log(other.gameObject.name);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
            
            Debug.Log(other.gameObject.name);
        
    }
}
