using UnityEngine;

/// <summary>
/// Display the raycast distance
/// </summary>
public class DisplayRaycastDistance : MonoBehaviour
{
    [SerializeField] private float distance;
    public bool       collision;
    public GameObject collisionObject;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        collisionObject = null;
    }

    /// <summary>
    /// Update is called once per frame
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