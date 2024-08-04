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

        // 境界線を超えたら
        if (transform.position.y < borderLine)
        {
            // 最初に位置に戻す
            transform.position = startPos;
        }
    }
}