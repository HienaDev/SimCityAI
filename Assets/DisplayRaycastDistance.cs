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
        Debug.DrawRay(new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward * distance, Color.red);
        Debug.DrawRay(new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward * distance, Color.red);
        Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z - 1.5f), gameObject.transform.forward * distance, Color.red);
        Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z + 1.5f), gameObject.transform.forward * distance, Color.red);

        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward, out hit, distance))
        {
            collision = true;

                collisionObject = hit.collider.gameObject;
        }

        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward, out hit, distance))
        {
            collision = true;

            collisionObject = hit.collider.gameObject;
        }

        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z), gameObject.transform.forward, out hit, distance))
        {
            collision = true;

            collisionObject = hit.collider.gameObject;
        }

        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z - 1.5f), gameObject.transform.forward, out hit, distance))
        {
            collision = true;

            collisionObject = hit.collider.gameObject;
        }

        if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z + 1.5f), gameObject.transform.forward, out hit, distance))
        {
            collision = true;

            collisionObject = hit.collider.gameObject;
        }

    }
}