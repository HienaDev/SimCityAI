using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckIfStopSign : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (context.drd.collisionObject != null && context.waitingForStopSign.shouldStop)
        {
            StopSign stopS = context.drd.collisionObject.GetComponent<StopSign>();
            if (stopS != null)
            {
                context.waitingForStopSign.shouldStop = false;
                //Debug.Log("waiting for stop soign");
                return State.Success;
            }
        }
        return State.Failure;
    }
}
