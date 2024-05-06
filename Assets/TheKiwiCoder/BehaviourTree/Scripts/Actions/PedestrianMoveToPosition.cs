using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class PedestrianMoveToPosition : ActionNode
{
    private float speed;

    protected override void OnStart() {
        context.agent.updatePosition = false;
        context.agent.updateRotation = false;
        context.agent.destination = blackboard.moveToPosition;
        speed = Random.Range(3.0f, 8.0f);
        context.agent.speed = speed;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance <= 1f) {
            return State.Success;
        }
        else { 
            Vector3 nextPosition = context.agent.nextPosition;
            Vector3 direction = nextPosition - context.transform.position;

            if (direction.magnitude > 0.1f) {
                context.transform.position += direction.normalized * speed * Time.deltaTime;
                context.transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        if (context.pedestrianController.IsDrunk) {
            return State.Failure;
        }

        if (context.pedestrianController.HasAccident) {
            return State.Failure;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Running;
    }
}