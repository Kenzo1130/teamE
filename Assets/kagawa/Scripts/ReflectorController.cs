using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // 親スクリプトへの参照
    private string targetTag;   // 衝突対象のタグ
    private string enemyTag;    // 敵のタグ
    private string bletTag;     // 無視するタグ

    // 初期化メソッド
    public void Initialize(ReflectorDirector spawner, string targetTag, string enemyTag, string bletTag)
    {
        this.spawner = spawner;
        this.targetTag = targetTag;
        this.enemyTag = enemyTag;
        this.bletTag = bletTag;
    }

    // 衝突検出メソッド
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) || collision.gameObject.CompareTag(enemyTag))
        {
            spawner.DestroyCurrentInstance();
        }
        else if (collision.gameObject.CompareTag(bletTag))
        {
            // Bletタグの物体との衝突時には何もしない
        }
    }
}
