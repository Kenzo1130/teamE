using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField]
    public GameObject Bulletobj; // �����������v���n�u(Bullet) 
    [SerializeField,Header("�e�𔭎˂��鎞�Ԃ̊Ԋu")]
    float Shottime;              //�e�𔭎˂��鎞�Ԃ̊Ԋu

    private float Shotcount;     //�ݒ肵��Shottime�ɂȂ�܂ł̃J�E���g������֐�


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

    private void Shotting ()
    {
        Shotcount += Time.deltaTime;
        if (Shotcount < Shottime)   
        {
            return;     //Shotcount�̒l����Shottime�̒l��菬�����ꍇ�͏����������Ȃ�Ȃ�
        }

        GameObject bulletobj = Instantiate(Bulletobj);  //Bulletobj���Ăяo���֐�
        bulletobj.transform.position = transform.position + new Vector3(0f, transform.lossyScale.y / -2.0f, 0f);     //�e�����˂����ʒu��Enemy�I�u�W�F�N�g�̔����̂����ɂ���
        Shotcount = 0.0f;   //�e�𔭎˂��邽�уJ�E���g�����Z�b�g����

    }


}
