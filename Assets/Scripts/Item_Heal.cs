using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Heal : MonoBehaviour
{
    // �񕜗�
    public int healAmount = 1;
    
    public string targetTag = "Target";   // �ՓˑΏۂ̃^�O
    public void OnTriggerEnter2D(Collider2D other)
    {
        // "Player"�^�O�̕��̂ƐG�ꂽ�Ƃ�
        if (other.CompareTag(targetTag))
        {
            PlayerLifeController playerHP = other.GetComponent<PlayerLifeController>();
            if (playerHP != null)
            {
                playerHP.Heal(healAmount); // HP��1��
            }
            Destroy(gameObject); // �A�C�e��������
        }
    }
}
