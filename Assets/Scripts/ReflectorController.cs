using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    public float lifeTime = 5.0f; // ブロックが存在する時間（秒）

    void Start()
    {
        Destroy(gameObject, lifeTime); // 一定時間後に自身を破壊
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
