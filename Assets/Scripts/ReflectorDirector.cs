using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    public GameObject blockPrefab; // ドラッグアンドドロップで設定するブロックのプレハブ
    public float timerMax = 1.0f; // 生成間隔（秒）
    float timer = 0f; // タイマー

    void Start()
    {

    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) // 左クリックを検出
        {
           

            if (timer < 0f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // 2D座標に設定

                Instantiate(blockPrefab, mousePosition, Quaternion.identity);

                timer = timerMax;
            }
        }
    }
  
    
}
