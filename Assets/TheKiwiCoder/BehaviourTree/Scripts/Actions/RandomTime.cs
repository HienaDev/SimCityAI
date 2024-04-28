using UnityEngine;
using TheKiwiCoder;

public class RandomTime : ActionNode
{
    public float maxTime;
    float randomTime;

    protected override void OnStart() {
        maxTime = context.gameManager.GetMaxTime();
        randomTime = Random.Range(0f, maxTime);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.time = randomTime;

        return State.Success;
    }
}
