using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField]
    public GameObject Bulletobj; // �����������v���n�u(Bullet) 

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Bulletobj, transform.position, Quaternion.identity);    //Bullet�𐶐�����

        GameObject g = GameObject.FindWithTag("Bullet");    //Bullet�^�O�̍��W��T��
        Debug.Log("Name: " + g.name);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
