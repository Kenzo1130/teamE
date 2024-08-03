using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public GameObject[] Life;
    private bool Result = false;
    [SerializeField] GameObject UI_Result;

    int life;

    void Start()
    {
        life = Life.Length;
        UI_Result.SetActive(false);
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
        ResultGame();
    }
    public void Heal(int healAmount)
    {
        life += healAmount;
        if (life > Life.Length) life = Life.Length;
    }
    void ResultGame()
    {
        Time.timeScale = 0;
        UI_Result.SetActive(true);
        Result = true;
    }
    public void RetryButtonPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitButtonPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
