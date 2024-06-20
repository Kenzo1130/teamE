using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public GameObject Life_1;
    public GameObject Life_2;
    public GameObject Life_3;
    public GameObject Life_4;
    public GameObject Life_5;
    public GameObject textGameOver;

    private int life = 5;

    void Update()
    {
 
    }

    //“G‚ÆÕ“Ë‚µ‚½‚Æ‚«‚Ìˆ—
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            life--;
            //“G‚ð”j‰ó‚·‚é
            Destroy(collision.gameObject);
            if (life == 4)
            {
                Life_5.SetActive(false);
            }
            else if (life == 3)
            {
                Life_5.SetActive(false);
                Life_4.SetActive(false);
            }
            else if (life == 2)
            {
                Life_5.SetActive(false);
                Life_4.SetActive(false);
                Life_3.SetActive(false);
            }
            else if (life == 1)
            {
                Life_5.SetActive(false);
                Life_4.SetActive(false);
                Life_3.SetActive(false);
                Life_2.SetActive(false);
            }
            else if (life == 0)
            {
                Life_5.SetActive(false);
                Life_4.SetActive(false);
                Life_3.SetActive(false);
                Life_2.SetActive(false);
                Life_1.SetActive(false);
                ShowGameOver();
            }
        }
        if(life > 0)
        {
            life = 0;
        }
    }

    void ShowGameOver()
    {
        textGameOver.SetActive(true);
    }

}



