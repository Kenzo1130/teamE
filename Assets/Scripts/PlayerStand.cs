using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStand : MonoBehaviour
{
    public GameObject[] Life;
    public GameObject textGameOver;
    public AudioClip DamageSound;
    public AudioClip HealSound;
    AudioSource audioSource;
    

    int life;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(DamageSound);
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
        audioSource.PlayOneShot(HealSound);
        life += healAmount;
        if (life > Life.Length) life = Life.Length;
    }
}



