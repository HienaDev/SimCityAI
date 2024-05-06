using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TrafficLightGreen : ActionNode
{
    protected override void OnStart() {
        context.renderer.material.color = Color.green;
        context.trafficCollider.gameObject.SetActive(false);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
