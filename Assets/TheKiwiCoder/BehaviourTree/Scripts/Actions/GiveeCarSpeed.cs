using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class GiveeCarSpeed : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
       //Debug.Log(context.defaultAgentSpeed);
        //Debug.Log(context.agent.acceleration);
        if (context.agent.speed < context.defaultAgentSpeed)
        {
            context.agent.speed += context.agent.acceleration * Time.deltaTime;
            return State.Running;
        }
        return State.Success;
    }
}
