using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] GameObject UI_Result;

    PlayerLife playerLife;

    int life;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        UI_Result.SetActive(false);
    }
    void Update()
    {

        life = playerLife.lifea(life);

        if (life <= 0)
        {
            ShowGameOver();
        }
    }

    void ShowGameOver()
    {
        ResultGame();
    }
    void ResultGame()
    {
        //Time.timeScale = 0;
        UI_Result.SetActive(true);
    }
    public void RetryButtonPress()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Tani_testScene");
    }
    public void ExitButtonPress()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
