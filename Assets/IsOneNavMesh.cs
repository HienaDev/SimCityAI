//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class IsOneNavMesh : MonoBehaviour
//{

//    private NavMeshAgent agent;
//    private bool gotToNavMesh;
//    private Vector3 targetPos;
//    private Vector3 initialPos;
//    private float lerpValue;

//    // Start is called before the first frame update
//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (agent.isOnOffMeshLink && !gotToNavMesh)
//        {
//            gotToNavMesh = true;
//            targetPos = agent.nextOffMeshLinkData.endPos;
//            initialPos = transform.position;
//            lerpValue = 0f;
//        }

//        if (agent.isOnOffMeshLink && gotToNavMesh)
//        {
//            transform.position = Vector3.Lerp(initialPos, targetPos, lerpValue);
//            lerpValue += 1 / agent.speed * Time.deltaTime;
//        }

//        if(lerpValue > 1)
//        {
//            gotToNavMesh = false;
//        }
//    }

//    IEnumerator NormalSpeed(NavMeshAgent agent)
//    {
//        OffMeshLinkData data = agent.currentOffMeshLinkData;
//        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
//        while (agent.transform.position != endPos)
//        {
//            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);
//            yield return null;
//        }
//    }
//}

using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using TMPro;

public enum OffMeshLinkMoveMethod
{
    Teleport,
    NormalSpeed,
    Parabola
}

[RequireComponent(typeof(NavMeshAgent))]
public class AgentLinkMover : MonoBehaviour
{
    //wowo
    public OffMeshLinkMoveMethod method = OffMeshLinkMoveMethod.NormalSpeed;
    IEnumerator Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                if (method == OffMeshLinkMoveMethod.NormalSpeed)
                    yield return StartCoroutine(NormalSpeed(agent));
                else if (method == OffMeshLinkMoveMethod.Parabola)
                    yield return StartCoroutine(Parabola(agent, 2.0f, 0.5f));
                agent.CompleteOffMeshLink();
            }
            yield return null;
        }
    }

    IEnumerator NormalSpeed(NavMeshAgent agent)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        while (agent.transform.position != endPos)
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);  
            yield return null;
        }
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
}
