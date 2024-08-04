using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreResult : MonoBehaviour
{

    [SerializeField] Text scoreResult;


    PlayerLife playerLife;
    int life;
    float time;
    // Start is called before the first frame update
    void Start()
    {

        scoreResult.enabled = false;
        //playerLife = FindObjectOfType<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //life = playerLife.lifea(life);
        // Debug.Log(life);
        // if (life == 0)
        // {
        //     scoreResult.enabled = true;
        //     scoreResult.text = "" + ScoreManager.instance.GetScore();
        //     return;

        // }
        // //else
        // //{
        // //    scoreResult.enabled = false;
        // //}
    }


}
