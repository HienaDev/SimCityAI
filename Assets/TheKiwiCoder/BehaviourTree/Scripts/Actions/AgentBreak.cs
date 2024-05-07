using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEditor;

public class AgentBreak : ActionNode
{

    [SerializeField] private float stoppingSpeed;
    private float defaultSpeed;

    protected override void OnStart() {
        defaultSpeed = context.agent.speed;

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        //Debug.Log("breaking");

        if(context.agent.speed > 0)
        {
            context.agent.speed -= stoppingSpeed * Time.deltaTime;
            return State.Running;
        }


        return State.Success;
    }
}
