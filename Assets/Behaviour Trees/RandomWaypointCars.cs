using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomWaypointCars : ActionNode
{

    public GameObject[] waypoints;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (context.readyForNextDestination)
        {
            context.readyForNextDestination = false;
            GameObject waypoint = waypoints[Random.Range(0, waypoints.Length)];
            blackboard.moveToPosition.x = waypoint.transform.position.x;
            blackboard.moveToPosition.z = waypoint.transform.position.z;
            return State.Success;
        }
        return State.Failure;
    }
}
