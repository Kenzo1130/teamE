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

        // ‹«ŠEü‚ğ’´‚¦‚½‚ç
        if (transform.position.y < borderLine)
        {
            // Å‰‚ÉˆÊ’u‚É–ß‚·
            transform.position = startPos;
        }
    }
}