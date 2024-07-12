using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    public GameObject prefab;   // 使用するプレハブ
    public Vector3 initialPosition = new Vector3(1.0f, 1.0f, 0); // 任意の初期位置
    public float resetTime = 3.0f;   // リセットまでの時間
    public float destroyTime = 5.0f; // プレハブが消えるまでの時間
    public string targetTag = "Target";   // 衝突対象のタグ
    public string enemyTag = "Enemy";     // 敵のタグ
    public string bletTag = "Blet";       // 無視するタグ

    private GameObject currentInstance;   // 現在のプレハブインスタンス
    private bool isMouseDown = false;   // マウスが押されているかどうか
    private bool isWaiting = false;   // 一時停止中かどうか
    private Collider2D currentCollider;   // 現在のプレハブのコライダー

    void Start()
    {
        // プレハブのインスタンスを任意の初期位置に配置
        CreateInstanceAtInitialPosition();
    }

    void Update()
    {
        if (isWaiting)
        {
            // 一時停止中はマウスの動きに反応しない
            return;
        }

        if (isMouseDown && Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z座標を0に設定して2D平面上に固定

            // プレハブの位置をマウスの位置に設定
            currentInstance.transform.position = mousePosition;
        }
        else if (isMouseDown && Input.GetMouseButtonUp(0))
        {
            // マウスの左ボタンが離された時
            isMouseDown = false;

            // コライダーを有効化
            if (currentCollider != null)
            {
                currentCollider.enabled = true;
            }

            // プレハブを一定時間後に消去するコルーチンを開始
            StartCoroutine(DestroyInstanceAfterTime(destroyTime));

            // コライダー有効化前の衝突チェックコルーチンを開始
            StartCoroutine(CheckForCollisionBeforeEnableCollider());

            // プレハブをリセットするコルーチンを開始
            StartCoroutine(ResetPositionAfterTime(resetTime));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            // マウスの左ボタンが押された時
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z座標を0に設定して2D平面上に固定

            // マウス位置がプレハブの範囲内にある場合のみ反応
            if (currentCollider != null && currentCollider.OverlapPoint(mousePosition))
            {
                isMouseDown = true;
                currentCollider.enabled = false; // マウスで持っている間はコライダーを無効化
            }
        }
    }

    // プレハブのインスタンスを任意の初期位置に配置する関数
    private void CreateInstanceAtInitialPosition()
    {
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = initialPosition;
        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            currentCollider.enabled = true; // 初期状態でコライダーを有効化
        }

        // 衝突処理を担当するコンポーネントを追加
        ReflectorController collisionHandler = currentInstance.AddComponent<ReflectorController>();
        collisionHandler.Initialize(this, targetTag, enemyTag, bletTag);
    }

    // 一定時間後にプレハブを元の位置に戻すコルーチン
    private IEnumerator ResetPositionAfterTime(float time)
    {
        isWaiting = true;
        yield return new WaitForSeconds(time);
        isWaiting = false;

        // プレハブを元の位置に戻す
        if (currentInstance != null)
        {
            currentInstance.transform.position = initialPosition;

            // コライダーを有効化
            if (currentCollider != null)
            {
                currentCollider.enabled = true;
            }
        }
    }

    // コライダーを有効化する前に衝突チェックを行うコルーチン
    private IEnumerator CheckForCollisionBeforeEnableCollider()
    {
        yield return new WaitForEndOfFrame();

        if (currentInstance != null && currentCollider != null)
        {
            // プレハブのBoundsを取得
            Bounds bounds = currentCollider.bounds;

            // プレハブのBoundsでOverlapBoxを実行
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(targetTag) || hitCollider.CompareTag(enemyTag))
                {
                    DestroyCurrentInstance();
                    yield break;
                }
            }

            currentCollider.enabled = true;
        }
    }

    // 一定時間後にプレハブを削除し、新しいインスタンスを生成するコルーチン
    private IEnumerator DestroyInstanceAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // 現在のプレハブを削除
        DestroyCurrentInstance();

        // 新しいプレハブのインスタンスを任意の初期位置に生成
        CreateInstanceAtInitialPosition();
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