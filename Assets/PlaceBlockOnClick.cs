using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlockOnClick : MonoBehaviour
{
    public GameObject blockPrefab; // �h���b�O�A���h�h���b�v�Őݒ肷��u���b�N�̃v���n�u

    
    void Start()
    {
      
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // ���N���b�N�����o
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // 2D���W�ɐݒ�

            Instantiate(blockPrefab, mousePosition, Quaternion.identity);

           
        }
    }
}
