using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomWait : ActionNode
{
    float startTime;

    protected override void OnStart() {
        startTime = Time.time;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (Time.time - startTime > blackboard.time) {
            return State.Success;
        }

        return State.Running;
    }
}
