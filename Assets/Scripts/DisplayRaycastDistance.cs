using System.Collections;
using System.Collections.Generic;
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

        collision = false;
        collisionObject = null;

        RaycastHit hit;
        Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward * distance, Color.red);


        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward, out hit, distance))
        {
            collisionObject = hit.collider.gameObject;
            if ((collisionObject.transform != gameObject.transform))
            {
                //Debug.Log(collisionObject.name + " collided with on script " + gameObject.name);
                collision = true;
            }


        }


    }
}