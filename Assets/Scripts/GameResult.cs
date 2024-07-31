using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    int HP = 0;
    private bool Result = false;
    [SerializeField] GameObject UI_Result;

    void Update()
    {
        if (HP <= 0)
        {
            ResultGame();
        }
    }

    void ResultGame()
    {
        Time.timeScale = 0;
        UI_Result.SetActive(true);
        Result = true;
    }

    public void RetryButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitButtonPress()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
