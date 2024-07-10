using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 衝突処理を担当するコンポーネント
public class CollisionHandler : MonoBehaviour
{
    private ReflectorDirector spawner;
    public string targetTag = "Target"; // 衝突対象のタグ
    public float destroyDelay = 1.0f;    // 衝突後の消滅までの遅延時間

    public void Initialize(ReflectorDirector spawner)
    {
        this.spawner = spawner;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // 衝突対象のタグを持つオブジェクトと衝突した場合
            StartCoroutine(DestroyAfterDelay());
        }
    }

    // 一定時間後に消滅するコルーチン
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        if (spawner != null)
        {
            spawner.DestroyCurrentInstance();
        }
    }
}
