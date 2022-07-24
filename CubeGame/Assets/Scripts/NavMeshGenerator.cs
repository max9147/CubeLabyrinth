using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> _surfaces;

    public void BakeNavMesh()
    {
        foreach (var item in _surfaces)
        {
            item.BuildNavMesh();
        }
    }
}