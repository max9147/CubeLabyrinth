using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGeneration : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            Vector3 trapPos = new Vector3(Random.Range(0, 9) * 2, 0.55f, Random.Range(0, 9) * 2);
            if (trapPos.x + trapPos.z > 2)
            {
                Instantiate(trapPrefab, trapPos, Quaternion.identity);
            }
        }
    }
}