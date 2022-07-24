using UnityEngine;
using UnityEngine.AI;

public class PathRenderer : MonoBehaviour
{
    private LineRenderer _line;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _agent = GetComponent<NavMeshAgent>();
    }

    public void DrawPath()
    {
        _line.SetPosition(0, transform.position + new Vector3(0, 0.5f, 0));
        _line.positionCount = _agent.path.corners.Length;

        for (int i = 1; i < _agent.path.corners.Length; i++)
        {
            _line.SetPosition(i, _agent.path.corners[i] + new Vector3(0, 0.5f, 0));
        }
    }
}