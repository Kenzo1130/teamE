using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public GameObject[] Life;
    public GameObject textGameOver;

    private int life = 5;

    void Update()
    {
 
    }

    //敵と衝突したときの処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //残機を減らす
            life--;

            //敵を破壊する
            Destroy(collision.gameObject);
           
            for(int i = 0;i < Life.Length; i++)
            {
                Life[i].SetActive(i < life);
            }
            if (life == 0)
            {
                ShowGameOver();
            }
        }
        if(life < 0)
        {
            life = 0;
        }
    }

    void ShowGameOver()
    {
        textGameOver.SetActive(true);
    }

}



