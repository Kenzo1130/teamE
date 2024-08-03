using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreResult : MonoBehaviour
{
    public static ScoreManager instance;
    public Text Resultsocre;

    ScoreManager scoreManager;
    int score;

    PlayerLife playerLife;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        playerLife = FindObjectOfType<PlayerLife>();
        Resultsocre.enabled = false;
        score = 0;
        Resultsocre.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        life = playerLife.lifea(life);
        score = scoreManager.AddScore(score);

        if (life <= 0)
        {
            Resultsocre.text = "" + score;
            Resultsocre.enabled = true;
        }
    }
}
