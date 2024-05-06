using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    private bool isDrunk;
    private bool hasAccident;
    private float drunkStartTime;
    private float drunkDuration;

    /// <summary>
    /// Gets or sets a value indicating whether this pedestrian is drunk.
    /// </summary>
    /// <value> Boolean to set if is drunk </value>
    public bool IsDrunk { get => isDrunk; set => isDrunk = value; }

    /// <summary>
    /// Gets or sets a value indicating whether this pedestrian has an accident.
    /// </summary>
    /// <value> Boolean to define if there is an accident </value>
    public bool HasAccident { get => hasAccident; set => hasAccident = value; }

    /// <summary>
    /// Change of the pedestrian getting drunk.
    /// </summary>
    /// <param name="chaosChance"> Change from the pedestrian getting drunk </param>
    public void ChangeOfGettingDrunk(float chaosChance)
    {
        float chance = Random.Range(0f, 100f);

        if (chance < chaosChance)
        {
            SetDrunkState(true);
        }
    }

    /// <summary>
    /// Sets the drunk state of the pedestrian.
    /// </summary>
    /// <param name="state"> Boolean to set the pedestrian drunk or not </param>
    public void SetDrunkState(bool state)
    {
        isDrunk = state;

        if (isDrunk)
        {
            drunkStartTime = Time.time;
            drunkDuration = Random.Range(0, GameManager.Instance.GetMaxChaosTime);
        }
    }

    /// <summary>
    /// The pedestrian stops being drunk after a certain time.
    /// </summary>
    private void StopBeingDrunk()
    {
        if (Time.time - drunkStartTime > drunkDuration)
        {
            SetDrunkState(false);
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
       if (isDrunk) 
       {
           StopBeingDrunk();
       }
    }
}
