using UnityEngine;
using TheKiwiCoder;

public class DeactivatePedestrian : ActionNode
{
    protected override void OnStart() {
    
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.DeactivateAllMeshRenderers();

        context.gameManager.RemovePedestrian();

        return State.Success;
    }
}
