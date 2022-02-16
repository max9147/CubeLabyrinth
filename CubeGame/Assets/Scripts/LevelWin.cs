using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    [SerializeField] private Animator fadeAnim;

    public IEnumerator WinDelay()
    {
        GetComponent<PlayerMovement>().DeactivatePlayer();
        fadeAnim.SetTrigger("PlayFade");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}