using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;

public class MoveToPositionCar : ActionNode
{
    public float speed = 5;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 40.0f;
    public float tolerance = 1.0f;

    protected override void OnStart()
    {
        //context.agent.stoppingDistance = stoppingDistance;
        //context.agent.speed = speed;
        context.agent.destination = blackboard.moveToPosition;
        //context.agent.updateRotation = updateRotation;
        //context.agent.acceleration = acceleration;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        

        if (context.agent.pathPending)
        {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            context.icd.DeactivateMesh();
            context.gameManager.RemoveCar();
            context.collider.enabled = false;
            context.agent.enabled = false;
            context.readyForNextDestination = true;
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Failure;
    }
}
