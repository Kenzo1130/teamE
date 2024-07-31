using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public GameObject hpBarPrefab;
    private GameObject hpBarInstance;
    private Image hpFillImage;
    private RectTransform hpBarRect;
    private Canvas canvas;
    private float currentHP;
    public float maxHP = 100;
    public float speed = -3;
    // 敵が与えるダメージ量（敵の場合）
    public float Emdamage = 10f;
    public float Emdamege_fire = 10f;
    public float Emdamege_shark = 10f;
    public float Emdamege_bat = 10f;

    // このキャラクターが敵かどうか
    public string bulletTag = "Bullet";
    public string bulletTag_fire = "FireSpBullet";
    public string bulletTag_shark = "SharkSpBullet";
    public string bulletTag_bat = "BatBullet";
    public string reflectorg = "Reflector";

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

    //効果音
    public AudioClip enemydeath;
    public AudioClip enemydamage;
    AudioSource audioSource; // AudioSourceコンポーネント

    private Collider2D currentCollider;   // 現在のプレハブのコライダー

    void Start()
    {
        currentCollider = GetComponent<Collider2D>();

        currentCollider.enabled = true;

        audioSource = GetComponent<AudioSource>();

        currentHP = maxHP;

        // メインキャンバスを見つける
        canvas = FindObjectOfType<Canvas>();

        // HPバーを生成し、キャンバスの子にする
        hpBarInstance = Instantiate(hpBarPrefab);
        hpBarRect = hpBarInstance.transform.Find("health").GetComponent<RectTransform>();
        hpFillImage = hpBarRect.Find("bar").GetComponent<Image>();

        // HPバーの位置をキャラクターの頭上に表示する
        Vector3 worldPosition = transform.position + new Vector3(0, 1.5f, 0); // キャラクターの頭上の位置にオフセット
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        hpBarRect.anchoredPosition = screenPosition;
    }
    void Update()
    {
        // HPバーの位置をキャラクターの頭上に表示する
        Vector3 worldPosition = transform.position + new Vector3(0, 1.5f, 0); // キャラクターの頭上の位置にオフセット
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        hpBarRect.anchoredPosition = screenPosition;
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 敵がプレイヤーにダメージを与える
        if (collision.gameObject.CompareTag(bulletTag))
        {
            // 上昇中のオブジェクトを消滅させる
            TakeDamage(Emdamage);
            if(currentHP > 0)
            {
                Destroy(collision.gameObject);
            }
        }
        //else if (collision.gameObject.CompareTag(bulletTag))
        //{
        //    TakeDamage(Emdamege_fire);
        //    if (currentHP > 0)
        //    {
        //        Destroy(collision.gameObject);
        //    }
        //}
        else if (collision.gameObject.CompareTag(reflectorg))
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(hpBarInstance);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float Emdamage)
    {
        float thresholdDamage = currentHP * EmdamageMultiplier;
        currentHP -= Emdamage;
        if (currentHP < 0) currentHP = 0;
        hpFillImage.fillAmount = currentHP / maxHP;
        if (currentHP <= 0 && Emdamage > thresholdDamage)
        {
            
            currentCollider.enabled = false;
            // 大きなダメージを受けたときの処理
            PlaySpecialDieAnimation();
        }
        else if (currentHP <= 0)
        {
            
            currentCollider.enabled = false;
            Die();
        }
        else
        {
            audioSource.PlayOneShot(enemydamage);
        }
    }
    public float GetCurrentHP()
    {
        return currentHP;
    }
    void Die()
    {
        // 通常の死亡モーション
        //animator.SetTrigger("Die");
        // スコアを加算
        ScoreManager.instance.AddScore(scoreValue);

        // 1秒後にオブジェクトを破壊
        Destroy(gameObject, 1f);

        Destroy(hpBarInstance, 1f);
        // アイテムを落下させる
        TryDropItem();
        audioSource.PlayOneShot(enemydeath);
    }

    void PlaySpecialDieAnimation()
    {
        // 特別な死亡モーション
        //animator.SetTrigger("Explode");

        // スコアを加算
        ScoreManager.instance.AddScore(scoreValue);

        // 1秒後にオブジェクトを破壊
        Destroy(gameObject, 1f);

        Destroy(hpBarInstance, 1f);
        // アイテムを落下させる
        TryDropItem();
        audioSource.PlayOneShot(enemydeath);
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
