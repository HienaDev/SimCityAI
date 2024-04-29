using UnityEngine.AI;
using TheKiwiCoder;

public class IsDrunk : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.pedestrianController.IsDrunk) {
            context.agent.agentTypeID = NavMesh.GetSettingsByIndex(2).agentTypeID;
            return State.Success;
        }
        if (!context.pedestrianController.IsDrunk){
            return State.Failure;
        }

        return State.Running;
    }
}
