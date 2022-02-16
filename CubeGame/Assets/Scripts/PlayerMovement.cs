using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerCube;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform goal;

    private GameObject curPlayer;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GetComponent<NavMeshGenerator>().BakeNavMesh();
        curPlayer = Instantiate(playerCube, spawnPoint.position, Quaternion.identity);
        GetComponent<Shield>().SetPlayer(curPlayer);
        StartCoroutine(SpawnWaitTime());
    }

    private void ActivatePlayer()
    {
        curPlayer.GetComponent<NavMeshAgent>().SetDestination(goal.position);
        StartCoroutine(WaitDraw());
    }

    public void DeactivatePlayer()
    {
        curPlayer.GetComponent<NavMeshAgent>().speed = 0;
    }

    private IEnumerator SpawnWaitTime()
    {
        yield return new WaitForSeconds(2f);        
        ActivatePlayer();
    }

    private IEnumerator WaitDraw()
    {
        yield return new WaitForSeconds(0.1f);
        curPlayer.GetComponent<PathRenderer>().DrawPath();
    }
}