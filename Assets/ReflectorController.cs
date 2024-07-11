using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Փˏ�����S������R���|�[�l���g
public class CollisionHandler : MonoBehaviour
{
    private ReflectorDirector spawner;
    public string targetTag = "Target"; // �ՓˑΏۂ̃^�O
    public float destroyDelay = 1.0f;    // �Փˌ�̏��ł܂ł̒x������

    public void Initialize(ReflectorDirector spawner)
    {
        this.spawner = spawner;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // �ՓˑΏۂ̃^�O�����I�u�W�F�N�g�ƏՓ˂����ꍇ
            StartCoroutine(DestroyAfterDelay());
        }
    }

    // ��莞�Ԍ�ɏ��ł���R���[�`��
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        if (spawner != null)
        {
            spawner.DestroyCurrentInstance();
        }
    }
}
