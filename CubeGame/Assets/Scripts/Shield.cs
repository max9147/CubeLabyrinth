using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] Slider shieldSlider;
    [SerializeField] Material materialShielded;
    [SerializeField] Material materialNormal;

    private GameObject player;
    private float shieldTime = 2f;
    private bool isShielded = false;

    private void FixedUpdate()
    {
        if (shieldTime <= 0)
        {
            isShielded = false;
        }
        if (isShielded)
        {
            shieldTime -= Time.deltaTime;
            shieldSlider.value = shieldTime;
        }
        else if (shieldTime <= 2f)
        {
            shieldTime += Time.deltaTime;
            shieldSlider.value = shieldTime;
        }    
    }

    public void SetPlayer(GameObject curPlayer)
    {
        player = curPlayer;
    }

    public void ActivateShield()
    {
        isShielded = true;
        player.GetComponent<Renderer>().material = materialShielded;
    }

    public void DeactivateShield()
    {
        isShielded = false;
        player.GetComponent<Renderer>().material = materialNormal;
    }

    public bool GetStatus()
    {
        return isShielded;
    }
}