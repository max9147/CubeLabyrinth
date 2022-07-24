using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] private Slider _shieldSlider;
    [SerializeField] private Material _materialShielded;
    [SerializeField] private Material _materialNormal;
    [SerializeField] private GameSettings _gameSettings;

    private GameObject _player;
    private float _shieldTime = 2f;
    private bool _isShielded = false;

    private void Awake()
    {
        _shieldTime = _gameSettings.ShieldTime;
        _shieldSlider.maxValue = _gameSettings.ShieldTime;
    }

    private void FixedUpdate()
    {
        if (_shieldTime <= 0)
            DeactivateShield();

        if (_isShielded)
        {
            _shieldTime -= Time.deltaTime;
            _shieldSlider.value = _shieldTime;
        }
        else if (_shieldTime <= _gameSettings.ShieldTime)
        {
            _shieldTime += Time.deltaTime;
            _shieldSlider.value = _shieldTime;
        }
    }

    public void SetPlayer(GameObject curPlayer)
    {
        _player = curPlayer;
    }

    public void ActivateShield()
    {
        _isShielded = true;
        _player.GetComponent<Renderer>().material = _materialShielded;
    }

    public void DeactivateShield()
    {
        _isShielded = false;
        _player.GetComponent<Renderer>().material = _materialNormal;
    }

    public bool GetStatus()
    {
        return _isShielded;
    }
}