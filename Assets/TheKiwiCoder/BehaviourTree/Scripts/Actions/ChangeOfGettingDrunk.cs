using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TheKiwiCoder;

public class ChangeOfGettingDrunk : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.pedestrianController.ChangeOfGettingDrunk
                                    (context.gameManager.GetChaosChance);

        if (context.pedestrianController.IsDrunk)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
