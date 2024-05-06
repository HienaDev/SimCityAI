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
        collision = true;
        collisionObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
