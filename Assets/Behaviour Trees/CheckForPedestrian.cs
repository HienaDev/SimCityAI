using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckForPedestrian : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
       
        if( context.cfpc.PedestrianCollision)
            return State.Success;

        return State.Failure;
    }
}
