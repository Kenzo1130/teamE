using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJumpStart : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    public void OnJump()
    {
        SceneManager.LoadScene(sceneName);
    }
}
