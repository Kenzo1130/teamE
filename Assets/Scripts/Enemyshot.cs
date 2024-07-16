using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField]
    public GameObject Bulletobj; // 生成したいプレハブ(Bullet) 

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Bulletobj, transform.position, Quaternion.identity);    //Bulletを生成する

        GameObject g = GameObject.FindWithTag("Bullet");    //Bulletタグの座標を探す
        Debug.Log("Name: " + g.name);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
