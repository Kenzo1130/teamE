using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // 親スクリプトへの参照
    private string targetTag;   // 衝突対象のタグ
    private string bullet;     // 無視するタグ

    // 初期化メソッド
    public void Initialize(ReflectorDirector spawner, string targetTag, string bletTag)
    {
        this.spawner = spawner;
        this.targetTag = targetTag;
        this.bullet = bletTag;
    }

    // 衝突検出メソッド
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            spawner.DestroyCurrentInstance();
        }
        else if (collision.gameObject.CompareTag(bullet))
        {
            // Bletタグの物体との衝突時には何もしない
        }
    }
}
