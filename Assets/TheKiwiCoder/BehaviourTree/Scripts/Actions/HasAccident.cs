using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class HasAccident : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (context.pedestrianController.HasAccident) {
            return State.Success;
        }

        if (!context.pedestrianController.HasAccident) {
            return State.Failure;
        }

        return State.Running;
    }
}
