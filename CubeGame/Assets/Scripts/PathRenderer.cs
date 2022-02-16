using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private NavMeshAgent agent;

    public void DrawPath()
    {
        line.SetPosition(0, transform.position + new Vector3(0, 0.5f, 0));
        line.positionCount = agent.path.corners.Length;

        for (int i = 1; i < agent.path.corners.Length; i++)
        {
            line.SetPosition(i, agent.path.corners[i] + new Vector3(0, 0.5f, 0));
        }
    }
}