using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    private bool isDrunk;
    private float drunkStartTime;
    private float drunkDuration;

    public bool IsDrunk { get => isDrunk; set => isDrunk = value; }

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

    public void ChangeOfGettingDrunk(float caosChange)
    {
        if (Random.Range(0f, 100f) < caosChange)
        {
            isDrunk = true;
            drunkStartTime = Time.time;
            drunkDuration = Random.Range(0, GameManager.Instance.GetMaxCaosTime);
        }
    }

    private void StopBeingDrunk()
    {
        if (isDrunk && Time.time - drunkStartTime > drunkDuration)
        {
            isDrunk = false;
        }
    }

    private void FixedUpdate()
    {
       if (isDrunk) 
       {
           StopBeingDrunk();
       }
    }
}
