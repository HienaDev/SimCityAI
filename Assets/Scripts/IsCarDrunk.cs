using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check if the car is drunk
/// </summary>
public class IsCarDrunk : MonoBehaviour
{
    [SerializeField] private float     chanceOfRandomDrunk = 0.01f;
    [SerializeField] private float     timeDrunk = 10f;
    [SerializeField] private Transform model;

    public bool isDrunk = false;

    private WaitForSeconds wfs;
    private List<MeshRenderer> renderers;
    
    /// <summary>
    /// Start is called before the first frame update
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

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void FixedUpdate()
    {
        if (Random.Range(0f, 100f) < chanceOfRandomDrunk)
            StartCoroutine(GetDrunk()); 
    }

    /// <summary>
    /// Activate the drunk state
    /// </summary>
    public void ActivateDrunk()
    {
        StartCoroutine(GetDrunk());
    }

    /// <summary>
    /// Get the car drunk
    /// </summary>
    /// <returns> Wait for seconds </returns>
    private IEnumerator GetDrunk()
    {
        TurnRed();
        isDrunk = true;

        yield return wfs;

        TurnWhite();

        isDrunk = false;
    }

    /// <summary>
    /// Turn the car green on accidents
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
    /// Deactive mesh when getting to destination
    /// </summary>
    public void DeactivateMesh()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }

    /// <summary>
    /// Activate mesh when getting to destination
    /// </summary>
    public void ActivateMesh()
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }
}

