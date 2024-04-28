using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ActivatePedestrian : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.ActivateAllMeshRenderers();

        context.gameManager.AddPedestrian();

        return State.Success;
    }
}
