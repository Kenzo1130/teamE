using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed;

    public float borderLine;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(0, -1 * scrollSpeed, 0);

        // ���E���𒴂�����
        if (transform.position.y < borderLine)
        {
            // �ŏ��Ɉʒu�ɖ߂�
            transform.position = startPos;
        }
    }
}