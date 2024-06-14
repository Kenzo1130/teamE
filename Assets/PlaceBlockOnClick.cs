using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlockOnClick : MonoBehaviour
{
    public GameObject blockPrefab; // �h���b�O�A���h�h���b�v�Őݒ肷��u���b�N�̃v���n�u
    public float timerMax = 1.0f; // �����Ԋu�i�b�j
    float timer = 0f; // �^�C�}�[

    void Start()
    {

    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) // ���N���b�N�����o
        {
           

            if (timer < 0f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // 2D���W�ɐݒ�

                Instantiate(blockPrefab, mousePosition, Quaternion.identity);

                timer = timerMax;
            }
        }
    }
  
    
}
