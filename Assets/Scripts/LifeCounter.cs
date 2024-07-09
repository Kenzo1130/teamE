using UnityEngine;

public class IconController : MonoBehaviour
{
    [SerializeField]
    GameObject[] icon;

    int num = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            num++;
            ShowIcon(num);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            num--;
            ShowIcon(num);
        }
    }

    void ShowIcon(int number)
    {
        for (int i = 0; i < icon.Length; i++)
        {
            icon[i].SetActive(false);
        }

        for (int i = 0; i < number; i++)
        {
            icon[i].SetActive(true);
        }
    }
}