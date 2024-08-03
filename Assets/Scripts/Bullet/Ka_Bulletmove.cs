using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ka_Bulletmove : MonoBehaviour
{
    [SerializeField, Header("�e�̑���")] float Speed; //�e�̂͑���
    [SerializeField, Header("�e�̈З�")] float Power = 60; //�e�̈З�
    [SerializeField, Header("���˕Ԃ�̋���")] float magnification; //���˕Ԃ����e�̃X�s�[�h�Ɋ|����{��

    Rigidbody2D Rigid;
    
    Vector3 direction = Vector3.down;

    public string targetTag = "Target";   // �Փ˔�����s���^�O

    private Collider2D currentCollider;   // ���݂̃v���n�u�̃R���C�_�[

    public Rect validArea;    // �C�ӂ͈̔�

    Vector2 position;

    PlayerLife playerLife;

    int life;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        Rigid = GetComponent<Rigidbody2D>();
        currentCollider = GetComponent<CircleCollider2D>();
        currentCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        life = playerLife.lifea(life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Move();

            position = transform.position;

            if (!IsWithinValidArea(position))
            {
                Destroy(gameObject);
            }
        }
    }

    private void Move()
    {
        Rigid.velocity = direction * Speed;     //�I�u�W�F�N�g�̌����ɑ�����������v�Z
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag != "Bullet")
        {
            if (collision.gameObject.CompareTag(targetTag))
            {
                direction = collision.transform.up;     //�G�ꂽ�I�u�W�F�N�g�ɑ΂��Đ����ɒ��˕Ԃ�
                Speed *= magnification;     //�I�u�W�F�N�g�ɐG�ꂽ��̓X�s�[�h���T�{�̑����ɂȂ�
                // �^�O��ύX
                gameObject.tag = "Bullet";
                currentCollider.isTrigger = false;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HPBarController controller = collision.gameObject.GetComponent<HPBarController>();
        if (gameObject.tag == "Bullet")
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
               
                controller.TakeDamage(Power);

                // �_���[�W��^�������HP��0�ȉ��ɂȂ����ꍇ�A�e���ђʂ�����
                if (controller.GetCurrentHP() <= 0)
                {
                    // �e���ђʂ����邽�߁A�Փ˂𖳎�
                    Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
                    return;
                }
                Destroy(gameObject);
            }
        }

    }
    //���̂��C�ӂ͈͓̔��ɂ��邩�ǂ������`�F�b�N����֐�
    private bool IsWithinValidArea(Vector3 position)
    {
        return validArea.Contains(new Vector2(position.x, position.y));
    }
    public void lifeBullet(int lifenow)
    {
        life = lifenow;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
