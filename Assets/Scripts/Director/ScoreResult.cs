using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreResult : MonoBehaviour
{
    public static ScoreResult iNstance;
    public Text scoreResult;

    
    PlayerLife playerLife;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        
        playerLife = FindObjectOfType<PlayerLife>();
        scoreResult.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       life = playerLife.lifea(life);
       

        if (life <= 0)
        {
            scoreResult.text = "" + ScoreManager.instance.GetScore();
            scoreResult.enabled = true;
            return;
            
        }
        else scoreResult.enabled = false;
    }

    public void HideText()
    {
        scoreResult.enabled = false; // テキストを非表示にする
    }
}
