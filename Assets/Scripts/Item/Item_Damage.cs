using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Damage : MonoBehaviour
{
    // 回復量
    public int healAmount = 1;
    
    public string targetTag = "Target";   // 衝突対象のタグ

    PlayerLife playerLife;
    int life;
    private void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
    }
    private void Update()
    {
        life =playerLife.lifea(life);
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
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
