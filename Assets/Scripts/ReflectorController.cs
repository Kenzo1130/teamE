using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // �e�X�N���v�g�ւ̎Q��
    private string targetTag;   // �ՓˑΏۂ̃^�O
    private string enemyTag;    // �G�̃^�O
    private string bletTag;     // ��������^�O

    // ���������\�b�h
    public void Initialize(ReflectorDirector spawner, string targetTag, string enemyTag, string bletTag)
    {
        this.spawner = spawner;
        this.targetTag = targetTag;
        this.enemyTag = enemyTag;
        this.bletTag = bletTag;
    }

    // �Փˌ��o���\�b�h
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) || collision.gameObject.CompareTag(enemyTag))
        {
            spawner.DestroyCurrentInstance();
        }
        else if (collision.gameObject.CompareTag(bletTag))
        {
            // Blet�^�O�̕��̂Ƃ̏Փˎ��ɂ͉������Ȃ�
        }
    }
}
