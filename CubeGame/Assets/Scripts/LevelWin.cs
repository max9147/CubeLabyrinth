using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    [SerializeField] private Animator _fadeAnim;

    public IEnumerator WinDelay()
    {
        GetComponent<PlayerMovement>().DeactivatePlayer();
        _fadeAnim.SetTrigger("PlayFade");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}