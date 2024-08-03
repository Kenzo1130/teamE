using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ka_Enemyshot : MonoBehaviour
{
    [System.Serializable]
    public class BulletPrefab
    {
        public GameObject prefab;
        public float probability; // �m���i���v100�ɂȂ�悤�ɐݒ�j
    }

    [SerializeField]
    public List<BulletPrefab> bulletPrefabs; // �����̃v���n�u�Ƃ��̊m���������X�g
    [SerializeField, Header("�e�𔭎˂��鎞�Ԃ̊Ԋu")]
    float Shottime;              //�e�𔭎˂��鎞�Ԃ̊Ԋu

    public float bulletposition;

    private float Shotcount;     // �ݒ肵��Shottime�ɂȂ�܂ł̃J�E���g������ϐ�


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
                return; // Shotcount�̒l��Shottime�̒l��菬�����ꍇ�͏����������Ȃ�Ȃ�
            }

            GameObject bulletObj = SelectBullet(); // �m���ɉ����Ēe��I��
            if (bulletObj != null)
            {
                GameObject bullet = Instantiate(bulletObj); // �I�������e�̃v���n�u���C���X�^���X��
                bullet.transform.position = transform.position + new Vector3(0f, -transform.lossyScale.y - bulletposition, 0f); // �e�����˂����ʒu��Enemy�I�u�W�F�N�g�̔����̈ʒu�ɂ���
            }
            Shotcount = 0.0f; // �e�𔭎˂��邽�уJ�E���g�����Z�b�g����
    }

    private GameObject SelectBullet()
    {
        float totalProbability = 0f;
        foreach (var bullet in bulletPrefabs)
        {
            totalProbability += bullet.probability; // �m���̍��v���v�Z
        }

        float randomValue = Random.Range(0f, totalProbability); // �����_���Ȓl�𐶐�
        float cumulativeProbability = 0f;

        foreach (var bullet in bulletPrefabs)
        {
            cumulativeProbability += bullet.probability; // �ݐϊm�����v�Z
            if (randomValue < cumulativeProbability) // �����_���Ȓl���ݐϊm����菬�����ꍇ
            {
                return bullet.prefab; // �I�����ꂽ�v���n�u��Ԃ�
            }
        }

        return null; // �����I�΂�Ȃ������ꍇ�i�ʏ�͂��肦�Ȃ��j
    }
}

