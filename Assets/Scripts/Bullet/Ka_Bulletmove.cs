using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ka_Bulletmove : MonoBehaviour
{
    [SerializeField, Header("�e�̑���")] float Speed; //�e�̂͑���
    [SerializeField, Header("�e�̈З�")] float Power; //�e�̈З�
    [SerializeField, Header("���˕Ԃ�̋���")] float magnification; //���˕Ԃ����e�̃X�s�[�h�Ɋ|����{��

    private Rigidbody2D Rigid;
    Vector3 direction = Vector3.down;

    public string targetTag = "Target";   // �Փ˔�����s���^�O

    private Collider2D currentCollider;   // ���݂̃v���n�u�̃R���C�_�[

    public Rect validArea;    // �C�ӂ͈̔�

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
        Rigid.velocity = direction * Speed;     //�I�u�W�F�N�g�̌����ɑ�����������v�Z
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(targetTag))
        {
            direction = collision.transform.up;     //�G�ꂽ�I�u�W�F�N�g�ɑ΂��Đ����ɒ��˕Ԃ�
            Speed *= magnification;     //�I�u�W�F�N�g�ɐG�ꂽ��̓X�s�[�h���T�{�̑����ɂȂ�
            // �^�O��ύX
            gameObject.tag = "Bullet";
        }
    }
    private bool IsWithinValidArea(Vector3 position)
    {
        return validArea.Contains(new Vector2(position.x, position.y));
    }
}
