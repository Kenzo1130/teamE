using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    // プレハブを設定
    public GameObject prefab;
    public float timerMax = 1.0f; // 生成間隔（秒）
    float timer = 0f; // タイマー

    private GameObject currentInstance;
    private bool isMouseDown = false;
    private Collider2D currentCollider;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // マウスの左ボタンが押されている間
            if (Input.GetMouseButton(0))
            {
                if (currentInstance == null)
                {
                    // プレハブのインスタンスを生成
                    currentInstance = Instantiate(prefab);

                    // インスタンスのCollider2Dコンポーネントを取得して無効化
                    currentCollider = currentInstance.GetComponent<Collider2D>();
                    if (currentCollider != null)
                    {
                        currentCollider.enabled = false;
                    }
                }

                // マウスのワールド座標を取得
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // z座標を0に設定して2D平面上に固定

                // 物体の位置をマウスの位置に設定
                currentInstance.transform.position = mousePosition;

                isMouseDown = true;
            }
            else if (isMouseDown && Input.GetMouseButtonUp(0))
            {
                // マウスの左ボタンが離された時
                isMouseDown = false;

                // Collider2Dコンポーネントを有効化
                if (currentCollider != null)
                {
                    currentCollider.enabled = true;
                }

                // プレハブのインスタンスの参照をクリア
                currentInstance = null;
                currentCollider = null;
                timer = timerMax;
            }
        }
    }

}
