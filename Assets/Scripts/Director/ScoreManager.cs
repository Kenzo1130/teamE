using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public Text scoreText;
    int score = 0;

    void Start()
    {


        scoreText.text = "" + score;
    }

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "" + score;

    }

    public int GetScore()
    {
        Debug.Log(score);
        return score;
    }

}
