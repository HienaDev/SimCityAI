using UnityEngine;
using TheKiwiCoder;

public class RandomTime : ActionNode
{
    public float maxTime = 10.0f;
    float randomTime;

    protected override void OnStart() {
        randomTime = Random.Range(0f, maxTime);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.time = randomTime;

        return State.Success;
    }
}
