using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMchange : MonoBehaviour
{
    static public BGMchange instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public AudioSource A_BGM;//AudioSource型の変数A_BGMを宣言　対応するAudioSourceコンポーネントをアタッチ
    public AudioSource B_BGM;//AudioSource型の変数B_BGMを宣言　対応するAudioSourceコンポーネントをアタッチ

    private string beforeScene;//string型の変数beforeSceneを宣言 


                               // Start is called before the first frame update
    void Start()
        {
        beforeScene = "TestScene2";//起動時のシーン名 を代入しておく
        A_BGM.Play();//A_BGMのAudioSourceコンポーネントに割り当てたAudioClipを再生

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定
        //Scene1からScene2へ
        if (beforeScene == "TestScene2" && nextScene.name == "TestScene2")
        {
            A_BGM.Stop();
            B_BGM.Play();
        }

        // Scene1からScene2へ
        if (beforeScene == "TestScene2" && nextScene.name == "TestScene2")
        {
            A_BGM.Play();
            B_BGM.Stop();
        }

    }

        // Update is called once per frame
        void Update()
        {

        }
    
}

