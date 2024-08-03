using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ka_Enemyshot : MonoBehaviour
{
    [System.Serializable]
    public class BulletPrefab
    {
        public GameObject prefab;
        public float probability; // 確率（合計100になるように設定）
    }

    [SerializeField]
    public List<BulletPrefab> bulletPrefabs; // 複数のプレハブとその確率を持つリスト
    [SerializeField, Header("弾を発射する時間の間隔")]
    float Shottime;              //弾を発射する時間の間隔

    public float bulletposition;

    private float Shotcount;     // 設定したShottimeになるまでのカウントをする変数


    // Start is called before the first frame update
    void Start()
    {
        Shotcount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Shotting();
    }

    private void Shotting()
    {
            Shotcount += Time.deltaTime;
            if (Shotcount < Shottime)
            {
                return; // Shotcountの値がShottimeの値より小さい場合は処理をおこなわない
            }

            GameObject bulletObj = SelectBullet(); // 確率に応じて弾を選択
            if (bulletObj != null)
            {
                GameObject bullet = Instantiate(bulletObj); // 選択した弾のプレハブをインスタンス化
                bullet.transform.position = transform.position + new Vector3(0f, -transform.lossyScale.y - bulletposition, 0f); // 弾が発射される位置をEnemyオブジェクトの半分の位置にする
            }
            Shotcount = 0.0f; // 弾を発射するたびカウントをリセットする
    }

    private GameObject SelectBullet()
    {
        float totalProbability = 0f;
        foreach (var bullet in bulletPrefabs)
        {
            totalProbability += bullet.probability; // 確率の合計を計算
        }

        float randomValue = Random.Range(0f, totalProbability); // ランダムな値を生成
        float cumulativeProbability = 0f;

        foreach (var bullet in bulletPrefabs)
        {
            cumulativeProbability += bullet.probability; // 累積確率を計算
            if (randomValue < cumulativeProbability) // ランダムな値が累積確率より小さい場合
            {
                return bullet.prefab; // 選択されたプレハブを返す
            }
        }

        return null; // 何も選ばれなかった場合（通常はありえない）
    }
}

