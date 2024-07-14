using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string targetTag = "Target";   // 衝突対象のタグ
    void OnTriggerEnter2D(Collider2D other)
    {
        // "Player"タグの物体と触れたとき
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject); // アイテムを消去
        }
    }
}
