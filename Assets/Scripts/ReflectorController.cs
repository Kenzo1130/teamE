using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // �e�X�N���v�g�ւ̎Q��
    private string targetTag;   // �ՓˑΏۂ̃^�O
    private string bullet;     // ��������^�O
    AudioClip collisionEnemy; // �G�Փˎ��̃T�E���h
    AudioClip collisionBullet; // �e�Փˎ��̃T�E���h
    AudioSource audioSource; // AudioSource�R���|�[�l���g

    // ���������\�b�h
    public void Initialize(ReflectorDirector spawner, string EnemyTag, string BulletTag,
                           AudioClip collisionEnemy, AudioClip collisionBullet,
                           AudioSource audioSource)
    {
        this.spawner = spawner;
        this.targetTag = EnemyTag;
        this.bullet = BulletTag;
        this.collisionEnemy = collisionEnemy;
        this.collisionBullet = collisionBullet;
        this.audioSource = audioSource;
    }

    // �Փˌ��o���\�b�h
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            audioSource.PlayOneShot(collisionEnemy);
            spawner.DestroyCurrentInstance();
        }
        else if (collision.gameObject.CompareTag(bullet))
        {
            audioSource.PlayOneShot(collisionBullet);
        }
    }
}
