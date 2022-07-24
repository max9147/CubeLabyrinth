using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void SetPause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}