using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class DrunkMoveToPosition : ActionNode
{
    private float speed;

    protected override void OnStart() {
        context.agent.updatePosition = false;
        context.agent.updateRotation = false;
        context.agent.destination = blackboard.moveToPosition;
        speed = Random.Range(4.0f, 7.0f);
        context.agent.speed = speed;
    }

    protected override void OnStop() {
        context.renderer.material.color = context.originalColor;
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

        if (!context.pedestrianController.IsDrunk) {
            return State.Failure;
        }

        if (context.pedestrianController.HasAccident) {
            return State.Failure;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }
        
        context.Blink();

        return State.Running;
    }
}
