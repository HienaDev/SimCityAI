using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    public class AccidentWait : ActionNode {
        float startTime;
        float randomTime;

        protected override void OnStart() {
            context.agent.isStopped = true;
            randomTime = Random.Range(0f, context.gameManager.GetMaxAccidentTime);
            startTime = Time.time;
            blackboard.time = randomTime;
        }

        protected override void OnStop() {
            context.renderer.material.color = context.originalColor;
            context.pedestrianController.HasAccident = false;
            context.agent.isStopped = false;
        }

        protected override State OnUpdate() {
            if (Time.time - startTime > randomTime) {
                return State.Success;
            }

            context.Blink();

            return State.Running;
        }
    }
}
