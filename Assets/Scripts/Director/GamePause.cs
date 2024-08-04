using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    private bool Pause = false;
    [SerializeField] GameObject UI_Pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        UI_Pause.SetActive(true);
        Pause = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Pause = false;
        UI_Pause.SetActive(false);
    }
    public void ResumeButtonPress()
    {
        Time.timeScale = 1;
        Pause = false;
        UI_Pause.SetActive(false);
    }
    public void ExitButtonPress()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
