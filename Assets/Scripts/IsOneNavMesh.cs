using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// The method to move the agent through the off mesh link
/// </summary>
public enum OffMeshLinkMoveMethod
{
    Teleport,
    NormalSpeed,
    Parabola
}

[RequireComponent(typeof(NavMeshAgent))]

/// <summary>
/// Move the agent through the off mesh link
/// </summary>
public class AgentLinkMover : MonoBehaviour
{
    public OffMeshLinkMoveMethod method = OffMeshLinkMoveMethod.NormalSpeed;

    /// <summary>
    /// Start the agent
    /// </summary>
    /// <returns> Wait for seconds </returns>
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

    /// <summary>
    /// Move the agent at normal speed
    /// </summary>
    /// <param name="agent"> The agent </param>
    /// <returns> Wait for seconds </returns>
    IEnumerator NormalSpeed(NavMeshAgent agent)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        while (agent.transform.position != endPos)
        {
            agent.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(agent.transform.position, endPos - agent.transform.position, 360, 1f));
            //Debug.Log(Quaternion.LookRotation(Vector3.RotateTowards(agent.transform.position, endPos - agent.transform.position, 360, 1f)));
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, endPos, agent.speed * Time.deltaTime);  
            yield return null;
        }
    }

    /// <summary>
    /// Move the agent through a parabola
    /// </summary>
    /// <param name="agent"> The agent </param>
    /// <param name="height"> The height of the parabola </param>
    /// <param name="duration"> The duration of the parabola </param>
    /// <returns></returns>
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
