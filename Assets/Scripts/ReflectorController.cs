using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorController : MonoBehaviour
{
    public float lifeTime = 5.0f; // �u���b�N�����݂��鎞�ԁi�b�j

    void Start()
    {
        Destroy(gameObject, lifeTime); // ��莞�Ԍ�Ɏ��g��j��
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
