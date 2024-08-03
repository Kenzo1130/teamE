using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heal : MonoBehaviour
{
    // �񕜗�
    public int healAmount = 1;
    
    public string targetTag = "Target";   // �ՓˑΏۂ̃^�O

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
        // "Player"�^�O�̕��̂ƐG�ꂽ�Ƃ�
        if (other.CompareTag(targetTag))
        {
            PlayerLife playerHP = other.GetComponent<PlayerLife>();
            if (playerHP != null)
            {
                playerHP.Heal(healAmount); // HP��1��
            }
            Destroy(gameObject); // �A�C�e��������
        }
    }
}
