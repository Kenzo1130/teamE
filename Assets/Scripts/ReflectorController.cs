using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    public float lifeTime = 5.0f; // �u���b�N�����݂��鎞�ԁi�b�j
    // ���̃^�O�����I�u�W�F�N�g�ƏՓ˂����ꍇ�ɍ폜����
    public string targetTag = "Enemy";

    void Start()
    {
        Destroy(gameObject, lifeTime); // ��莞�Ԍ�Ɏ��g��j��
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // �^�[�Q�b�g�^�O�����I�u�W�F�N�g�ƏՓ˂����ꍇ�A���̃Q�[���I�u�W�F�N�g��j�󂷂�
            Destroy(gameObject);
        }
    }
}
