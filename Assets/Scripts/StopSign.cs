using UnityEngine;

/// <summary>
/// Stop sign
/// </summary>
public class StopSign : MonoBehaviour
{
    /// <summary>
    /// When a car leaves a stop sign it goes back to having to stop on stop signs, so it only stops once per sign
    /// </summary>
    /// <param name="other"> Collider from the object we are colliding with </param>
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
