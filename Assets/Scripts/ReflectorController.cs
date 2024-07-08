using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    public float lifeTime = 5.0f; // ブロックが存在する時間（秒）
    // このタグを持つオブジェクトと衝突した場合に削除する
    public string targetTag = "Player";

    void Start()
    {
        Destroy(gameObject, lifeTime); // 一定時間後に自身を破壊
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ターゲットタグを持つオブジェクトと衝突した場合、このゲームオブジェクトを破壊する
            Destroy(gameObject);
        }
    }
}
