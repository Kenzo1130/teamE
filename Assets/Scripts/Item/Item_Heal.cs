using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heal : MonoBehaviour
{
    // 回復量
    public int healAmount = 1;
    
    public string targetTag = "Target";   // 衝突対象のタグ
    public void OnTriggerEnter2D(Collider2D other)
    {
        // "Player"タグの物体と触れたとき
        if (other.CompareTag(targetTag))
        {
            PlayerLife playerHP = other.GetComponent<PlayerLife>();
            if (playerHP != null)
            {
                playerHP.Heal(healAmount); // HPを1回復
            }
            Destroy(gameObject); // アイテムを消去
        }
    }
}
