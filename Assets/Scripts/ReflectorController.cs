using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // �e�X�N���v�g�ւ̎Q��
    private string targetTag;   // �ՓˑΏۂ̃^�O

    // ���������\�b�h
    public void Initialize(ReflectorDirector spawner, string targetTag)
    {
        this.spawner = spawner;
        this.targetTag = targetTag;
    }

    // �Փˌ��o���\�b�h
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            spawner.DestroyCurrentInstance();
        }
    }
}
