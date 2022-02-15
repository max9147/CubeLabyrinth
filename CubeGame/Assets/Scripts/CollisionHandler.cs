using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject gameSystems;

    private void Start()
    {
        gameSystems = GameObject.Find("GameSystems");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            StartCoroutine(gameSystems.GetComponent<LevelWin>().WinDelay());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DeathTrap"))
        {
            if (!gameSystems.GetComponent<Shield>().GetStatus())
            {
                gameSystems.GetComponent<PlayerMovement>().SpawnPlayer();
                Destroy(this.gameObject);
            }
        }
    }
}