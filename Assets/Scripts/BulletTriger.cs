using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriger : MonoBehaviour
{
    // このタグを持つオブジェクトに触れると当たり判定が有効になります
    public string targetTag = "TargetTag";
    private Collider2D playerCollider;

    void Start()
    {
        // プレイヤーのCollider2Dを取得
        playerCollider = GetComponent<Collider2D>();
        // 最初に当たり判定を無効にする
        playerCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 他のオブジェクトが指定されたタグを持っているか確認
        if (other.CompareTag(targetTag))
        {
            // 当たり判定を有効にする
            playerCollider.enabled = true;
        }
    }
}
