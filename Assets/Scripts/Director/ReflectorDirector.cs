using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    public GameObject[] prefabs;   // 使用するプレハブのリスト
    public Vector3 initialPosition = new Vector3(1.0f, 1.0f, 0); // 任意の初期位置
    public float resetTime = 3.0f;   // リセットまでの時間
    public float destroyTime = 5.0f; // プレハブが消えるまでの時間
    public string EnemyTag = "Enemy";   // 衝突対象のタグ
    public string bullet = "Bullet";       // 無視するタグ
    public string spbullet = "SpBullet";       // 無視するタグ
    public Rect validArea;    // 任意の範囲
    public Rect mouseClickArea; // マウスが押されてもプレハブを移動させる範囲
    public Vector2 initialColliderSize = new Vector2(1.0f, 1.0f); // 生成時のコライダーのサイズ
    public Vector2 releaseColliderSize = new Vector2(0.5f, 0.5f); // 離された時のコライダーのサイズ

    private GameObject currentInstance;   // 現在のプレハブインスタンス
    private bool isMouseDown = false;   // マウスが押されているかどうか
    private bool isWaiting = false;   // 一時停止中かどうか
    private Collider2D currentCollider;   // 現在のプレハブのコライダー

    public AudioClip SEspawn;
    public AudioClip collisionEnemy;
    public AudioClip collisionBullet;
    AudioSource audioSource;

    PlayerLife playerLife;
    int life;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        audioSource = GetComponent<AudioSource>();
        // プレハブのインスタンスを任意の初期位置に配置
        CreateInstanceAtInitialPosition();
    }

    void Update()
    {
        life = playerLife.lifea(life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }

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
            gameObject.tag = "Reflector";

            // マウスの左ボタンが離された時
            isMouseDown = false;

            // コライダーを有効化
            if (currentCollider != null)
            {
                SetColliderSize(currentCollider, releaseColliderSize); // 離されたときのコライダーサイズを設定
                currentCollider.enabled = true;
            }

            // 範囲内チェックを行い、範囲外なら初期位置に戻す
            if (!IsWithinValidArea(currentInstance.transform.position))
            {
                StartCoroutine(ResetPositionAfterTime(0));  // 即座に初期位置に戻す
                gameObject.tag = "Untagged";
            }
            else
            {
                // プレハブを一定時間後に消去するコルーチンを開始
                StartCoroutine(DestroyInstanceAfterTime(destroyTime));

                // コライダー有効化前の衝突チェックコルーチンを開始
                StartCoroutine(CheckForCollisionBeforeEnableCollider());

                // プレハブをリセットするコルーチンを開始
                StartCoroutine(ResetPositionAfterTime(resetTime));
            }

            audioSource.PlayOneShot(SEspawn); // マウスが離されたときのサウンド再生
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
            // mouseClickArea にも反応させる
            else if (mouseClickArea.Contains(new Vector2(mousePosition.x, mousePosition.y)))
            {
                isMouseDown = true;
                currentInstance.transform.position = mousePosition; // プレハブの位置をマウスの位置に設定
                currentCollider.enabled = false; // コライダーを無効化
            }
        }
    }

    // プレハブのインスタンスを任意の初期位置に配置する関数
    private void CreateInstanceAtInitialPosition()
    {
        if (prefabs.Length == 0) return;

        // ランダムにプレハブを選択
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = initialPosition;

        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            // 生成時のコライダーサイズを設定
            SetColliderSize(currentCollider, initialColliderSize);
            currentCollider.enabled = true; // 初期状態でコライダーを有効化
        }

        // 衝突処理を担当するコンポーネントを追加
        ReflectorController collisionHandler = currentInstance.AddComponent<ReflectorController>();
        collisionHandler.Initialize(this, EnemyTag, bullet, spbullet, collisionEnemy, collisionBullet, audioSource);
    }

    private void SetColliderSize(Collider2D collider, Vector2 size)
    {
        if (collider is BoxCollider2D boxCollider)
        {
            boxCollider.size = size; // BoxColliderのサイズを設定
        }
        else if (collider is CircleCollider2D circleCollider)
        {
            circleCollider.radius = size.x / 2; // CircleColliderの半径を設定
        }
        // 他のコライダータイプもここで設定できます
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
                // 初期位置に戻すときにコライダーサイズを元に戻す
                SetColliderSize(currentCollider, initialColliderSize);
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
                if (hitCollider.CompareTag(EnemyTag))
                {
                    audioSource.PlayOneShot(collisionEnemy);
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

    // 物体が任意の範囲内にあるかどうかをチェックする関数
    private bool IsWithinValidArea(Vector3 position)
    {
        return validArea.Contains(new Vector2(position.x, position.y));
    }
}
