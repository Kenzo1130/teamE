using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] Life;
    //public GameObject textGameOver;
    public AudioClip DamageSound;
    public AudioClip HealSound;
    AudioSource audioSource;
    

    int life ;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        life = Life.Length;
        //textGameOver.SetActive(false);
    }
    void Update()
    {
        lifea(life);

        Debug.Log(life);
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
            audioSource.PlayOneShot(DamageSound);
        }  
        else if (collision.CompareTag("Item")|| collision.CompareTag("Reflector"))
        {
            
        }
        else
        {
            life--;
            audioSource.PlayOneShot(DamageSound);
        }
    }

    void ShowGameOver()
    {
        //textGameOver.SetActive(true);
    }
    public void Heal(int healAmount)
    {
        audioSource.PlayOneShot(HealSound);
        life += healAmount;
        if (life > Life.Length) life = Life.Length;
    }

    public int lifea(int Life)
    {
        return life;
    }
}



