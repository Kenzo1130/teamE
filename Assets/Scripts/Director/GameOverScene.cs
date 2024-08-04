using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    [SerializeField] GameObject UI_Result;

    [SerializeField] Text scoreResult;


    PlayerLife playerLife;

    int life;



    bool targget = false;
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
            if (!targget)
            {
                Score();
                return;
            }
        }
    }

    void ShowGameOver()
    {
        ResultGame();
    }
    void ResultGame()
    {
        UI_Result.SetActive(true);

    }
    public void RetryButtonPress()
    {

        SceneManager.LoadScene("Tani_testScene");
    }
    public void ExitButtonPress()
    {

        SceneManager.LoadScene("TitleScene");
    }

    void Score()
    {
        targget = true;
        UI_Result.SetActive(true);
        scoreResult.enabled = true;
        scoreResult.text = "" + ScoreManager.instance.GetScore();
        return;
    }

}
