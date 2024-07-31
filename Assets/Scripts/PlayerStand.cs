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
        for (int i = 0; i < Stand.Length; i++)
        {
            Stand[i].SetActive(i < stand);
        }
    }

    //�G�ƏՓ˂����Ƃ��̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //�c�@�����炷
            stand--;
        }  
    }
}



