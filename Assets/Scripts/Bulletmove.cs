using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField,Header("弾の速さ")] float Speed; //弾のは速さ
    [SerializeField,Header("弾の威力")] float Power; //弾の威力
    [SerializeField, Header("跳ね返りの強さ")] float magnification; //跳ね返った弾のスピードに掛ける倍率

    private Rigidbody2D Rigid;
    Vector3 direction = Vector3.down;


    // Start is called before the first frame update
    void Start()
    {
      Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Rigid.velocity = direction * Speed;     //オブジェクトの向きに速さをかける計算
    }

    private void OnCollisionEnter2D(Collision2D collision)  //オブジェクトに接触したら呼び出される
    {
        direction = collision.transform.up;     //触れたオブジェクトに対して垂直に跳ね返る
        Speed *= magnification;     //オブジェクトに触れた後はスピードが５倍の速さになる
    }
}
