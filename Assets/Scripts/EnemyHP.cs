using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public HealthGauge healthGauge;

    // 敵が与えるダメージ量（敵の場合）
    public float Emdamage = 10f;

    // このキャラクターが敵かどうか
    public string targetag = "target";
    
    // 残りHPにかける数
    public float EmdamageMultiplier = 1.5f;
    
    // アイテムのプレハブ配列
    public GameObject[] itemPrefabs;

    // アイテムをドロップする確率
    public float dropProbability = 0.5f;

    // 落下スピード
    public float dropSpeed = 5f;

    // Animatorを追加
    public Animator animator;

    // 物体が消えたときに加算するスコア
    public int scoreValue = 10; 


    private void Start()
    {
        currentHP = maxHP;
        healthGauge.SetHP(currentHP, maxHP);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 敵がプレイヤーにダメージを与える
        if (collision.gameObject.CompareTag(targetag))
        {
            TakeDamage(Emdamage);
        }
    }
    public void TakeDamage(float Emdamage)
    {
        currentHP -= Emdamage;
        healthGauge.SetHP(currentHP, maxHP);
        // 残りHPにかける数を計算
        int thresholdDamage = Mathf.FloorToInt(currentHP * EmdamageMultiplier);

        if (currentHP <= 0 && Emdamage > thresholdDamage)
        {
            // 大きなダメージを受けたときの処理
            PlaySpecialDieAnimation();
        }
        else if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 通常の死亡モーション
        //animator.SetTrigger("Die");

        // スコアを加算
        ScoreManager.instance.AddScore(scoreValue);

        // 1秒後にオブジェクトを破壊
        Destroy(gameObject,1f);

        // アイテムを落下させる
        TryDropItem();
    }

    void PlaySpecialDieAnimation()
    {
        // 特別な死亡モーション
        //animator.SetTrigger("Explode");

        // スコアを加算
        ScoreManager.instance.AddScore(scoreValue);

        // 1秒後にオブジェクトを破壊
        Destroy(gameObject,1f);

        // アイテムを落下させる
        TryDropItem();  
    }

    void TryDropItem()
    {
        // 確率に基づいてアイテムをドロップ
        if (Random.value < dropProbability)
        {
            // ランダムなアイテムを選択
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject item = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = new Vector2(0, -dropSpeed); // 下方向に落下
            }
        }
    }

}
