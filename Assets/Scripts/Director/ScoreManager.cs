using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    int score = 0;
    PlayerLife playerLife;
    int life;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        score = 0;
        scoreText.text = "" + score;
    }
    void Update()
    {
        life = playerLife.lifea(life);
        if (life <= 0)
        {
            AddScore(0);
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "" + score;
        if (life <= 0)
        {
            AddScore(score);
        }
    }

    public int GetScore()
    {
        return score;
    }
}
