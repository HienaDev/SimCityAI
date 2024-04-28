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

        return State.Success;
    }
}
