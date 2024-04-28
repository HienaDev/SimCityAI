using UnityEngine;
using TheKiwiCoder;

public class WaitRandomTime : ActionNode
{
    public float maxTime = 10.0f;
    public float minTime = 1.0f;
    float startTime;
    float randomTime;

    protected override void OnStart() {
        startTime = Time.time;
        randomTime = Random.Range(minTime, maxTime);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.time = randomTime;

        if (Time.time - startTime > randomTime) {
            return State.Success;
        }

        return State.Running;
    }
}
