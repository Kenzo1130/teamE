using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject risingObjectPrefab; // 上昇するオブジェクトのプレハブ
    public string targetTag = "Target";   // 衝突判定を行うタグ
    private float fallSpeed;              // 落下速度

    void Start()
    {
        // 落下速度を設定（例：ランダムな速度）
        fallSpeed = Random.Range(1f, 5f);
    }

    void Update()
    {
        // オブジェクトを下に移動させる
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // 現在の位置に新しいオブジェクトを生成
            GameObject newRisingObject = Instantiate(risingObjectPrefab, transform.position, Quaternion.identity);

            // 新しいオブジェクトに上昇スクリプトを追加
            newRisingObject.AddComponent<RisingObject>().riseSpeed = fallSpeed;

            // 現在のオブジェクトを削除
            Destroy(gameObject);
        }
    }
}

