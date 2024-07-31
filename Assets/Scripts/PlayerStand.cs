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

    void Start()
    {

        stand = Stand.Length;

    }
    void Update()
    {
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

    //ìGÇ∆è’ìÀÇµÇΩÇ∆Ç´ÇÃèàóù
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //écã@Çå∏ÇÁÇ∑
            stand--;

            if(stand < 0)
            {
                stand = 0;
            }
        }  
    }
}



