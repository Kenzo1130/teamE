using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObject : MonoBehaviour
{
    public float riseSpeed; // 上昇速度

    void Update()
    {
        // オブジェクトを上に移動させる
        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 上昇中のオブジェクトを消滅させる
            Destroy(gameObject);
        }
    }
}
