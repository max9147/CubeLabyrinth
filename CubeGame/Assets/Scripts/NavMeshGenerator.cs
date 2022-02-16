using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> surfaces;

    public void BakeNavMesh()
    {
        foreach (var item in surfaces)
        {
            item.BuildNavMesh();
        }
    }
}