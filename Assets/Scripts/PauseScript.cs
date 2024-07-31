using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    bool isOnPause;

    public void puseTheGame()
    {
        if (isOnPause)
        {
            Time.timeScale = 1.0f;
            isOnPause = false;
        }
        else
        {
            Time .timeScale = 0.0f;
            isOnPause = true;
        }
    }
}
