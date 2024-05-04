using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TheKiwiCoder {

    // The context is a shared object every node has access to.
    // Commonly used components and subsytems should be stored here
    // It will be somewhat specfic to your game exactly what to add here.
    // Feel free to extend this class 
    public class Context {
        public GameObject gameObject;
        public Transform transform;
        public Animator animator;
        public Rigidbody physics;
        public NavMeshAgent agent;
        public float defaultAgentSpeed;
        public SphereCollider sphereCollider;
        public BoxCollider boxCollider;
        public CapsuleCollider capsuleCollider;
        public CharacterController characterController;
        public PedestrianController pedestrianController;
        public Renderer renderer;
        public GameManager gameManager;
        public Color originalColor;
        public MeshRenderer[] meshRenderers;
        public DisplayRaycastDistance drd;
        public TrafficCollider trafficCollider;
        public StopSignLogic waitingForStopSign;
        public bool readyForNextDestination = true;
       
        // Add other game specific systems here

        public static Context CreateFromGameObject(GameObject gameObject) {
            // Fetch all commonly used components
            Context context = new Context();
            context.gameObject = gameObject;
            context.transform = gameObject.transform;
            context.animator = gameObject.GetComponent<Animator>();
            context.physics = gameObject.GetComponent<Rigidbody>();
            context.agent = gameObject.GetComponent<NavMeshAgent>();
            context.sphereCollider = gameObject.GetComponent<SphereCollider>();
            context.boxCollider = gameObject.GetComponent<BoxCollider>();
            context.capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            context.characterController = gameObject.GetComponent<CharacterController>();
            context.pedestrianController = gameObject.GetComponent<PedestrianController>(); 
            context.meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            context.renderer = gameObject.GetComponentInChildren<Renderer>();
            context.gameManager = GameObject.FindObjectOfType<GameManager>();
            context.drd = gameObject.GetComponent<DisplayRaycastDistance>();
            context.trafficCollider = gameObject.GetComponentInChildren<TrafficCollider>();
            context.waitingForStopSign = gameObject.GetComponent<StopSignLogic>();
            context.defaultAgentSpeed = context.agent.speed;

            if (context.renderer != null) {
                context.originalColor = context.renderer.material.color;
            }
            
            // Add whatever else you need here...

            return context;
        }

        /// <summary>
        /// Deactivate all agent's mesh renderers.
        /// </summary>
        public void DeactivateAllMeshRenderers() {
            foreach (MeshRenderer meshRenderer in meshRenderers) {
                meshRenderer.enabled = false;
            }
        }

        /// <summary>
        /// Activate all agent's mesh renderers.
        /// </summary>
        public void ActivateAllMeshRenderers() {
            foreach (MeshRenderer meshRenderer in meshRenderers) {
                meshRenderer.enabled = true;
            }
        }

        /// <summary>
        /// Blink the agent from his original color to red and back.
        /// </summary>
        public void Blink() {
            float blinkSpeed = gameManager.GetBlinkSpeed;
            float lerpFactor = Mathf.PingPong(Time.time * blinkSpeed, 1);

            renderer.material.color = Color.Lerp(originalColor, Color.red , lerpFactor);
        }
    }
}