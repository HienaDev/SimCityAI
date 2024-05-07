using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomWaypointCars : ActionNode
{

    

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
            context.collider.enabled = true;
            context.gameManager.AddCar();
            context.icd.ActivateMesh();
            context.agent.enabled = true;
            GameObject waypoint = context.gameManager.CarWaypoints[Random.Range(0, context.gameManager.CarWaypoints.Length)];

            if (Vector3.Distance(context.gameObject.transform.position, waypoint.transform.position) < 50 ) 
            { 
                return State.Running;
            }

            blackboard.moveToPosition.x = waypoint.transform.position.x;
            blackboard.moveToPosition.z = waypoint.transform.position.z;
            return State.Success;
        }
        return State.Failure;
    }
}
