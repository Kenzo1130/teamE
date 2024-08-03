using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    private ReflectorDirector spawner;   // 親スクリプトへの参照
    private string targetTag;   // 衝突対象のタグ
    private string bullet;     // 無視するタグ
    private string spbullet;     // 無視するタグ
    AudioClip collisionEnemy; // 敵衝突時のサウンド
    AudioClip collisionBullet; // 弾衝突時のサウンド
    AudioSource audioSource; // AudioSourceコンポーネント

    // 初期化メソッド
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

    // 衝突検出メソッド
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
