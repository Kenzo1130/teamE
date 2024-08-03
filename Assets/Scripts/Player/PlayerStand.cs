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

    int life;

    public PlayerLife playerLife;

    void Start()
    {
        stand = Stand.Length;
    }
    void Update()
    {
        life = playerLife.lifea(life);

        switch (life)
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

    //�G�ƏՓ˂����Ƃ��̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //�c�@�����炷
            stand--;

            if(stand < 0)
            {
                stand = 0;
            }
        }  
    }

}



