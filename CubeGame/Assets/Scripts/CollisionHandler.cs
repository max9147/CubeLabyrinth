using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem explodePS;
    [SerializeField] private ParticleSystem confettiPS;

    private GameObject gameSystems;

    private void Start()
    {
        gameSystems = GameObject.Find("GameSystems");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Instantiate(confettiPS, transform.position, Quaternion.identity);
            StartCoroutine(gameSystems.GetComponent<LevelWin>().WinDelay());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DeathTrap"))
        {
            if (!gameSystems.GetComponent<Shield>().GetStatus())
            {
                Destroy(this.gameObject);
                gameSystems.GetComponent<PlayerMovement>().SpawnPlayer();
                Instantiate(explodePS, transform.position, Quaternion.identity);
            }
        }
    }
}