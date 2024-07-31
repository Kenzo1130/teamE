using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStand : MonoBehaviour
{
    public GameObject[] Stand;

    int stand;

    public PlayerLifeController playerLifeController;

    void Start()
    {
        stand = Stand.Length;
    }
    void Update()
    {
        stand = playerLifeController.life;

        switch (stand)
        {
            case 0:
                Stand[0].SetActive(true);
                Stand[4].SetActive(false);
                Stand[3].SetActive(false);
                Stand[2].SetActive(false);
                Stand[1].SetActive(false);
                break;
            case 1:
                Stand[0].SetActive(true);
                Stand[4].SetActive(false);
                Stand[3].SetActive(false);
                Stand[2].SetActive(false);
                Stand[1].SetActive(false);
                break;
            case 2:
                Stand[1].SetActive(true);
                Stand[4].SetActive(false);
                Stand[3].SetActive(false);
                Stand[2].SetActive(false);
                Stand[0].SetActive(false);
                break;
            case 3:
                Stand[2].SetActive(true);
                Stand[4].SetActive(false);
                Stand[3].SetActive(false);
                Stand[1].SetActive(false);
                Stand[0].SetActive(false);
                break;
            case 4:
                Stand[3].SetActive(true);
                Stand[4].SetActive(false);
                Stand[2].SetActive(false);
                Stand[1].SetActive(false);
                Stand[0].SetActive(false);
                break;
            case 5:
                Stand[4].SetActive(true);
                Stand[3].SetActive(false);
                Stand[2].SetActive(false);
                Stand[1].SetActive(false);
                Stand[0].SetActive(false);
                break;
        }
   
        //if (stand == 5)
        //{
        //    Stand[4].SetActive(true);
        //}
    }

    //敵と衝突したときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //残機を減らす
            stand--;

            if(stand < 0)
            {
                stand = 0;
            }
        }  
    }

}



