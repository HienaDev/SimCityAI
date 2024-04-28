using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomWaypoint : ActionNode
{
    public GameObject[] waypoints;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.moveToPosition.x = waypoints[Random.Range(0, waypoints.Length)].transform.position.x;
        blackboard.moveToPosition.z = waypoints[Random.Range(0, waypoints.Length)].transform.position.z;
        return State.Success;
    }
}
