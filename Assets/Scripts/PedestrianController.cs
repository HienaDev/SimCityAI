using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    private bool isDrunk;

    public bool IsDrunk => isDrunk;

    public void DeactivateAllMeshRenderers()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }

    public void ActivateAllMeshRenderers()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
    }

    private void Update() 
    {
        // DEBUG ONLY
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDrunk = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            isDrunk = false;
        }
        if (isDrunk)
            Debug.Log("Pedestrian is drunk");
        if (!isDrunk)
            Debug.Log("Pedestrian is not drunk");
    }
}
