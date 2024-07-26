using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshot : MonoBehaviour
{
    [SerializeField]
    public GameObject Bulletobj; // 生成したいプレハブ(Bullet) 
    [SerializeField]
    float Shottime;              //弾を発射する時間の間隔

    private float Shotcount;     //設定したShottimeになるまでのカウントをする関数


    // Start is called before the first frame update
    void Start()
    {
        Shotcount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Shotting();
    }

    private void Shotting ()
    {
        Shotcount += Time.deltaTime;
        if (Shotcount < Shottime)   
        {
            return;     //Shotcountの値ががShottimeの値より小さい場合は処理をおかなわない
        }

        GameObject bulletobj = Instantiate(Bulletobj);  //Bulletobjを呼び出す関数
        bulletobj.transform.position = transform.position + new Vector3(0f, transform.lossyScale.y / -2.0f, 0f);     //弾が発射される位置をEnemyオブジェクトの半分のいちにする
        Shotcount = 0.0f;   //弾を発射するたびカウントをリセットする

    }


}
