using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TrafficLightRed : ActionNode
{
    protected override void OnStart() {
        context.renderer.material.color = Color.red;
        context.trafficCollider.gameObject.SetActive(true);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
