using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{

    [SerializeField] GameObject UI_Result;

    int life;

    public PlayerLife playerLife;

    void Update()
    {
        life = playerLife.lifea(life);

        if (life <= 0)
        {
            ResultGame();
        }
    }

    void ResultGame()
    {
        Time.timeScale = 0;
        UI_Result.SetActive(true);
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
