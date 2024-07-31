using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField,Header("�e�̑���")] float Speed; //�e�̂͑���
    [SerializeField,Header("�e�̈З�")] float Power; //�e�̈З�
    [SerializeField, Header("���˕Ԃ�̋���")] float magnification; //���˕Ԃ����e�̃X�s�[�h�Ɋ|����{��

    private Rigidbody2D Rigid;
    Vector3 direction = Vector3.down;


    // Start is called before the first frame update
    void Start()
    {
      Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Rigid.velocity = direction * Speed;     //�I�u�W�F�N�g�̌����ɑ�����������v�Z
    }

    private void OnCollisionEnter2D(Collision2D collision)  //�I�u�W�F�N�g�ɐڐG������Ăяo�����
    {
        direction = collision.transform.up;     //�G�ꂽ�I�u�W�F�N�g�ɑ΂��Đ����ɒ��˕Ԃ�
        Speed *= magnification;     //�I�u�W�F�N�g�ɐG�ꂽ��̓X�s�[�h���T�{�̑����ɂȂ�
    }
}
