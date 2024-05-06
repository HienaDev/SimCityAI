using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;

public class CheckForCollision : ActionNode
{
    [SerializeField] private float distance;

    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {


        if (context.drd.collisionObject != null)
        {
            StopSign stopS = context.drd.collisionObject.GetComponent<StopSign>();
            if (stopS == null)
            { 
                if (context.drd.collision)
                {
                    Debug.Log(context.drd.collisionObject.name);

                    return State.Success;
                }
            }

            if (!context.drd.collision)
                {
                    Debug.Log("no collision");
                    return State.Failure;
                }
            
        }

        

        

        return State.Failure;
    }
}
