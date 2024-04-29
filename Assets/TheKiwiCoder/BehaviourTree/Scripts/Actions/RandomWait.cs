using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomWait : ActionNode
{
    float startTime;
    float randomTime;

    protected override void OnStart() {
        startTime = Time.time;
        randomTime = Random.Range(0f, context.gameManager.GetMaxDestinyTimePedestrians);
        blackboard.time = randomTime;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (Time.time - startTime > randomTime) {
            return State.Success;
        }

        return State.Running;
    }
}
