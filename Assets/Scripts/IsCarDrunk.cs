using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IsCarDrunk : MonoBehaviour
{
    public bool isDrunk = false;

    [SerializeField] private float chanceOfRandomDrunk = 0.01f;
    [SerializeField] private float timeDrunk = 10f;
    private WaitForSeconds wfs;

    [SerializeField] private Transform model;
    private List<MeshRenderer> renderers;

    

    

    private void FixedUpdate()
    {
        if (Random.Range(0f, 100f) < chanceOfRandomDrunk)
            StartCoroutine(GetDrunk());

        
    }

    public void ActivateDrunk()
    {
        StartCoroutine(GetDrunk());
    }

    private IEnumerator GetDrunk()
    {
        foreach(MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.red;
        }

        isDrunk = true;

        yield return wfs;

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.white;
        }

        isDrunk = false;

    }



    public void TurnGreen()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.green;
        }
    }

    public void TurnWhite()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.white;
        }
    }

    public void DeactivateMesh()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }

    public void ActivateMesh()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }
}

