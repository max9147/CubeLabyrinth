using UnityEngine;

public class TrapGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _trapPrefab;
    [SerializeField] private Transform _mazeContainer;
    [SerializeField] private GameSettings _gameSettings;

    private void Start()
    {
        for (int i = 0; i < _gameSettings.TrapsAmount; i++)
        {
            Vector3 trapPos = new Vector3(Random.Range(0, 9) * 2, 0.55f, Random.Range(0, 9) * 2);
            if (trapPos.x + trapPos.z > 2)
            {
                Instantiate(_trapPrefab, trapPos, Quaternion.identity).transform.parent = _mazeContainer;
            }
        }
    }
}