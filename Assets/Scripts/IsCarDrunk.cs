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

    
    /// <summary>
    /// Get the mesh from all objects of the car
    /// </summary>
    private void Start()
    {
        wfs = new WaitForSeconds(timeDrunk);
        renderers = new List<MeshRenderer>();

        

        foreach (Transform t in model)
        {
            //Debug.Log(t.gameObject.name);
            MeshRenderer mr = t.GetComponent<MeshRenderer>();
            if (mr != null)
                renderers.Add(mr);
        }
    }

    private void Update()
    {

    }

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
        TurnRed();
        isDrunk = true;

        yield return wfs;

        TurnWhite();

        isDrunk = false;

    }


    /// <summary>
    /// turn the car green on accidents
    /// </summary>
    public void TurnGreen()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.green;
        }
    }

    /// <summary>
    /// turn the car back to default
    /// </summary>
    public void TurnWhite()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.white;
        }
    }

    /// <summary>
    /// turn the car red when drunk
    /// </summary>
    public void TurnRed()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = Color.red;
        }
    }

    /// <summary>
    /// deactive mesh when getting to destination
    /// </summary>
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

