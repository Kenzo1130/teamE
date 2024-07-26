using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField] float Speed; //�e�̂͑���
    [SerializeField] float Power; //�e�̈З�

    private Rigidbody2D Rigid;


    // Start is called before the first frame update
    void Start()
    {
      Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Rigid.velocity = transform.up * Speed;
    }


}
