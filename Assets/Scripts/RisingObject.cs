using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingObject : MonoBehaviour
{
    public float riseSpeed; // �㏸���x

    void Update()
    {
        // �I�u�W�F�N�g����Ɉړ�������
        transform.Translate(Vector2.up * riseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �㏸���̃I�u�W�F�N�g�����ł�����
            Destroy(gameObject);
        }
    }
}
