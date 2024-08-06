using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // �e�X�N���v�g�ւ̎Q��
    private string targetTag;   // �ՓˑΏۂ̃^�O
    private string bullet;     // ��������^�O
    private string spbullet;     // ��������^�O
    AudioClip collisionEnemy; // �G�Փˎ��̃T�E���h
    AudioClip collisionBullet; // �e�Փˎ��̃T�E���h
    AudioSource audioSource; // AudioSource�R���|�[�l���g

    // ���������\�b�h
    public void Initialize(ReflectorDirector spawner, string EnemyTag, string BulletTag,
                           string SpBulletTag, AudioClip collisionEnemy, AudioClip collisionBullet,
                           AudioSource audioSource)
    {
        this.spawner = spawner;
        this.targetTag = EnemyTag;
        this.bullet = BulletTag;
        this.spbullet = SpBulletTag;
        this.collisionEnemy = collisionEnemy;
        this.collisionBullet = collisionBullet;
        this.audioSource = audioSource;
    }

    // �Փˌ��o���\�b�h
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag(targetTag))
        //{
        //    Debug.Log("b");
        //    audioSource.PlayOneShot(collisionEnemy);
        //    spawner.DestroyCurrentInstance();
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Reflector")
        {
            if (collision.CompareTag(targetTag))
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
}
