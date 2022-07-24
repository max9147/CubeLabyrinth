using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerCube;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _goal;
    [SerializeField] private GameSettings _gameSettings;

    private GameObject _curPlayer;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GetComponent<NavMeshGenerator>().BakeNavMesh();
        _curPlayer = Instantiate(_playerCube, _spawnPoint.position, Quaternion.identity);
        _curPlayer.GetComponent<NavMeshAgent>().speed = _gameSettings.CubeSpeed;
        GetComponent<Shield>().SetPlayer(_curPlayer);
        StartCoroutine(SpawnWaitTime());
    }

    private void ActivatePlayer()
    {
        _curPlayer.GetComponent<NavMeshAgent>().SetDestination(_goal.position);
        StartCoroutine(WaitDraw());
    }

    public void DeactivatePlayer()
    {
        _curPlayer.GetComponent<Rigidbody>().isKinematic = true;
    }

    private IEnumerator SpawnWaitTime()
    {
        yield return new WaitForSeconds(2f);
        ActivatePlayer();
    }

    private IEnumerator WaitDraw()
    {
        yield return new WaitForSeconds(0.1f);
        _curPlayer.GetComponent<PathRenderer>().DrawPath();
    }
}