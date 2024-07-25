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

    //“G‚ÆÕ“Ë‚µ‚½‚Æ‚«‚Ìˆ—
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Žc‹@‚ðŒ¸‚ç‚·
            life--;

            
        }  
        
        if (collision.CompareTag("Bullet"))
        {
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



