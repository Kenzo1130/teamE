using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    // プレハブを設定
    public GameObject prefab;

    // プレハブの初期位置に戻るまでの時間
    public float resetTime = 3.0f;

    private GameObject currentInstance;
    private bool isMouseDown = false;
    private Collider2D currentCollider;

    void Start()
    {
        // プレハブのインスタンスを右上に配置
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = GetTopRightPosition();
        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            currentCollider.enabled = false; // 最初は当たり判定を無効化
        }

        // プレハブにOnCollisionEnter2Dを持つコンポーネントを追加
        currentInstance.AddComponent<CollisionHandler>().Initialize(this);
    }

    void Update()
    {
        // マウスの左ボタンが押されている間
        if (Input.GetMouseButton(0))
        {
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

            // 一定時間後にプレハブを元の位置に戻すコルーチンを開始
            StartCoroutine(ResetPositionAfterTime(resetTime));
        }
    }

    // 画面の右上のワールド座標を取得する関数
    private Vector3 GetTopRightPosition()
    {
        Camera cam = Camera.main;
        Vector3 topRightScreen = new Vector3(Screen.width, Screen.height, cam.nearClipPlane);
        Vector3 topRightWorld = cam.ScreenToWorldPoint(topRightScreen);
        topRightWorld.z = 0; // z座標を0に設定して2D平面上に固定
        return topRightWorld;
    }

    // 一定時間後にプレハブを元の位置に戻すコルーチン
    private IEnumerator ResetPositionAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // プレハブを元の位置に戻す
        if (currentInstance != null)
        {
            currentInstance.transform.position = GetTopRightPosition();

            // Collider2Dコンポーネントを無効化
            if (currentCollider != null)
            {
                currentCollider.enabled = false;
            }
        }
    }

    // プレハブを削除する関数
    public void DestroyCurrentInstance()
    {
        if (currentInstance != null)
        {
            Destroy(currentInstance);
            currentInstance = null;
            currentCollider = null;
        }
    }
}


