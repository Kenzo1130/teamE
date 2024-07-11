using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // 親スクリプトへの参照
    private string targetTag;   // 衝突対象のタグ

    // 初期化メソッド
    public void Initialize(ReflectorDirector spawner, string targetTag)
    {
        this.spawner = spawner;
        this.targetTag = targetTag;
    }

    // 衝突検出メソッド
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            spawner.DestroyCurrentInstance();
        }
    }
}
