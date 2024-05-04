using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckForTrafficLight : ActionNode
{

    [SerializeField] private LayerMask trafficLightColliderLayer;
    [SerializeField] private float distance;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if(Physics.Raycast(context.gameObject.transform.position, context.gameObject.transform.forward, distance, trafficLightColliderLayer))
            return State.Success;

        return State.Failure;
    }
}
