using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ka_Bulletmove_fire : MonoBehaviour
{
    [SerializeField, Header("弾の速さ")] float Speed; //弾のは速さ
    [SerializeField, Header("弾の威力")] float Power; //弾の威力
    [SerializeField, Header("跳ね返りの強さ")] float magnification; //跳ね返った弾のスピードに掛ける倍率

    private Rigidbody2D Rigid;
    Vector3 direction = Vector3.down;

    public string targetTag = "Target";   // 衝突判定を行うタグ

    private Collider2D currentCollider;   // 現在のプレハブのコライダー

    public Rect validArea;    // 任意の範囲

    Vector2 position;


    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        currentCollider = GetComponent<CircleCollider2D>();
        currentCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        position = transform.position;

        if (!IsWithinValidArea(position))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        Rigid.velocity = direction * Speed;     //オブジェクトの向きに速さをかける計算
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag(targetTag))
        {
            direction = collision.transform.up;     //触れたオブジェクトに対して垂直に跳ね返る
            Speed *= magnification;     //オブジェクトに触れた後はスピードが５倍の速さになる
            // タグを変更
            gameObject.tag = "SpBullet";
        }


        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HPBarController controller = collision.GetComponent<HPBarController>();

        if (gameObject.tag == "SpBullet")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("a");
                Destroy(gameObject);
                controller.TakeDamage(Power);
            }
        }
    }
    //物体が任意の範囲内にあるかどうかをチェックする関数
    private bool IsWithinValidArea(Vector3 position)
    {
        return validArea.Contains(new Vector2(position.x, position.y));
    }
}
