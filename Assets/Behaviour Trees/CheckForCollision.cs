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
                Debug.DrawRay(new Vector3(context.gameObject.transform.position.x, context.gameObject.transform.position.y + 2, context.gameObject.transform.position.z), context.gameObject.transform.forward * distance, Color.red);
                if (context.drd.collision)
                {
                    Debug.Log("collision");

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
