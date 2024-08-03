using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;

    private void Start()
    {
        score = 0;
        scoreText.text = "" + score;
    }
    void Update()
    {
        ScoreA(score);
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

    public int AddScore(int amount)
    {
        score += amount;
        scoreText.text = "" + score;
        return score;
    }

    public int ScoreA(int score)
    {
        return score;
    }
}
