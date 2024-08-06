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

    public AudioSource A_BGM;//AudioSource�^�̕ϐ�A_BGM��錾�@�Ή�����AudioSource�R���|�[�l���g���A�^�b�`
    public AudioSource B_BGM;//AudioSource�^�̕ϐ�B_BGM��錾�@�Ή�����AudioSource�R���|�[�l���g���A�^�b�`

    private string beforeScene;//string�^�̕ϐ�beforeScene��錾 


                               // Start is called before the first frame update
    void Start()
        {
        beforeScene = "TestScene2";//�N�����̃V�[���� �������Ă���
        A_BGM.Play();//A_BGM��AudioSource�R���|�[�l���g�Ɋ��蓖�Ă�AudioClip���Đ�

        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h�@
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���
        //Scene1����Scene2��
        if (beforeScene == "TestScene2" && nextScene.name == "TestScene2")
        {
            A_BGM.Stop();
            B_BGM.Play();
        }

        // Scene1����Scene2��
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

