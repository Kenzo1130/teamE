using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLifeController : MonoBehaviour
{
    public GameObject[] Life;
    public GameObject textGameOver;

    int life;

    void Start()
    {
        life = Life.Length;
        textGameOver.SetActive(false);
    }
    void Update()
    {
        for (int i = 0; i < Life.Length; i++)
        {
            Life[i].SetActive(i < life);
        }
        if (life == 0)
        {
            ShowGameOver();
        }
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
        }  
        
        if (collision.CompareTag("Bullet"))
        {
            //残機を減らす
            life--;

            //敵を破壊する
            Destroy(collision.gameObject); 
        }
    }

    void ShowGameOver()
    {
        textGameOver.SetActive(true);
    }
    public void Heal(int healAmount)
    {
        life += healAmount;
        if (life > Life.Length) life = Life.Length;
    }
}



