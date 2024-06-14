using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlockOnClick : MonoBehaviour
{
    public GameObject blockPrefab; // ドラッグアンドドロップで設定するブロックのプレハブ

    
    void Start()
    {
      
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // 左クリックを検出
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // 2D座標に設定

            Instantiate(blockPrefab, mousePosition, Quaternion.identity);

           
        }
    }
}
