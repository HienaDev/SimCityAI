using UnityEngine;

/// <summary>
/// Check if the car is colliding with a pedestrian
/// </summary>
public class CheckForPedestrianCollision : MonoBehaviour
{
    /// <summary>
    /// If the car is colliding with a pedestrian
    /// </summary>
    /// <value> The car is or not colliding with a pedestrian </value>
    public bool PedestrianCollision {  get; private set; }
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        PedestrianCollision = false;
    }

    /// <summary>
    /// If we are no longer colliding with a pedestrian the boolean changes so that the car can move
    /// </summary>
    /// <param name="other"> Colider from the object we are colliding with </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = false;
    }

    /// <summary>
    /// If we are colliding with a pedestrian the boolean changes so that the car stops moving
    /// </summary>
    /// <param name="other"> Colider from the object we are colliding with </param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pedestrian"))
            PedestrianCollision = true;
    }

    
}
