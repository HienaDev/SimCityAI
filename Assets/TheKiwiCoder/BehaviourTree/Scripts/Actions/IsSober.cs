using TheKiwiCoder;
using UnityEngine.AI;
using UnityEngine;

public class IsSober : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {      
        if (!context.pedestrianController.IsDrunk) {
            context.agent.agentTypeID = NavMesh.GetSettingsByIndex(0).agentTypeID;
            return State.Success;
        }
        if (context.pedestrianController.IsDrunk){
            return State.Failure;
        }

        return State.Running;
    }
}
