using UnityEngine;
using TheKiwiCoder;

public class RandomTime : ActionNode
{
    public float maxTime = 5f;
    float randomTime;

    protected override void OnStart() {
        randomTime = Random.Range(0f, maxTime);
        blackboard.time = randomTime;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
