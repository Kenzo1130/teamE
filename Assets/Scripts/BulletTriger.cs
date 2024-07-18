using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriger : MonoBehaviour
{
    // ���̃^�O�����I�u�W�F�N�g�ɐG���Ɠ����蔻�肪�L���ɂȂ�܂�
    public string targetTag = "TargetTag";
    private Collider2D playerCollider;

    void Start()
    {
        // �v���C���[��Collider2D���擾
        playerCollider = GetComponent<Collider2D>();
        // �ŏ��ɓ����蔻��𖳌��ɂ���
        playerCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ���̃I�u�W�F�N�g���w�肳�ꂽ�^�O�������Ă��邩�m�F
        if (other.CompareTag(targetTag))
        {
            // �����蔻���L���ɂ���
            playerCollider.enabled = true;
        }
    }
}
