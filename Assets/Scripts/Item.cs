using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string targetTag = "Target";   // �ՓˑΏۂ̃^�O
    void OnTriggerEnter2D(Collider2D other)
    {
        // "Player"�^�O�̕��̂ƐG�ꂽ�Ƃ�
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject); // �A�C�e��������
        }
    }
}
