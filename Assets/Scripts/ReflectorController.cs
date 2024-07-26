using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // �e�X�N���v�g�ւ̎Q��
    private string targetTag;   // �ՓˑΏۂ̃^�O
    private string bullet;     // ��������^�O

    // ���������\�b�h
    public void Initialize(ReflectorDirector spawner, string EnemyTag, string bullet)
    {
        this.spawner = spawner;
        this.targetTag = EnemyTag;
        this.bullet = bullet;
    }

    // �Փˌ��o���\�b�h
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            spawner.DestroyCurrentInstance();
        }
        else if (collision.gameObject.CompareTag(bullet))
        {
            // Blet�^�O�̕��̂Ƃ̏Փˎ��ɂ͉������Ȃ�
        }
    }
}
