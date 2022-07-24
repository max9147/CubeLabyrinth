using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explodePS;
    [SerializeField] private ParticleSystem _confettiPS;

    private GameObject _gameSystems;

    private void Start()
    {
        _gameSystems = GameObject.Find("GameSystems");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Instantiate(_confettiPS, transform.position, Quaternion.identity);
            StartCoroutine(_gameSystems.GetComponent<LevelWin>().WinDelay());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("DeathTrap"))
        {
            if (!_gameSystems.GetComponent<Shield>().GetStatus())
            {
                Destroy(gameObject);
                _gameSystems.GetComponent<PlayerMovement>().SpawnPlayer();
                Instantiate(_explodePS, transform.position, Quaternion.identity);
            }
        }
    }
}