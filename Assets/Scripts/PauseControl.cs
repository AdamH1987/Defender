using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

    public void QuitGame()
    {
        SceneManager.LoadScene("Main menu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }

    }
    public void PauseButton()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
