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
    }

    // Update is called once per frame
    void Update()
    {
       Resultsocre.enabled = false;
       life = playerLife.lifea(life);
       

        if (life <= 0)
        {
            Resultsocre.text = "" + ScoreManager.instance.GetScore();
            Resultsocre.enabled = true;
            return;
            
        }
    }

    
}
