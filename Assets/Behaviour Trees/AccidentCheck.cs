using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class AccidentCheck : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if(context.cfa.Accident)
        {
            context.Blink();
            return State.Success;
        }
        if(!context.icd.isDrunk)
            context.icd.TurnWhite();

        return State.Failure;
    }
}
