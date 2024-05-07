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
    private void Start()
    {
        collisionObject = null;
    }

    /// <summary>
    /// We check with a raycast if we are colliding with an object that isn't us
    /// </summary>
    private void Update()
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
                collision = true;
            }


        }

    }
}