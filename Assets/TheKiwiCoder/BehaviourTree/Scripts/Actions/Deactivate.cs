using UnityEngine;
using TheKiwiCoder;

public class Deactivate : ActionNode
{
    protected override void OnStart() {
    
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.pedestrianController.DeactivateAllMeshRenderers();

        return State.Success;
    }
}
