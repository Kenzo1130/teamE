using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    // �v���n�u��ݒ�
    public GameObject prefab;

    // �v���n�u�̏����ʒu�ɖ߂�܂ł̎���
    public float resetTime = 3.0f;

    private GameObject currentInstance;
    private bool isMouseDown = false;
    private Collider2D currentCollider;

    void Start()
    {
        // �v���n�u�̃C���X�^���X���E��ɔz�u
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = GetTopRightPosition();
        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            currentCollider.enabled = false; // �ŏ��͓����蔻��𖳌���
        }

        // �v���n�u��OnCollisionEnter2D�����R���|�[�l���g��ǉ�
        currentInstance.AddComponent<CollisionHandler>().Initialize(this);
    }

    void Update()
    {
        // �}�E�X�̍��{�^����������Ă����
        if (Input.GetMouseButton(0))
        {
            // �}�E�X�̃��[���h���W���擾
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z���W��0�ɐݒ肵��2D���ʏ�ɌŒ�

            // ���̂̈ʒu���}�E�X�̈ʒu�ɐݒ�
            currentInstance.transform.position = mousePosition;

            isMouseDown = true;
        }
        else if (isMouseDown && Input.GetMouseButtonUp(0))
        {
            // �}�E�X�̍��{�^���������ꂽ��
            isMouseDown = false;

            // Collider2D�R���|�[�l���g��L����
            if (currentCollider != null)
            {
                currentCollider.enabled = true;
            }

            // ��莞�Ԍ�Ƀv���n�u�����̈ʒu�ɖ߂��R���[�`�����J�n
            StartCoroutine(ResetPositionAfterTime(resetTime));
        }
    }

    // ��ʂ̉E��̃��[���h���W���擾����֐�
    private Vector3 GetTopRightPosition()
    {
        Camera cam = Camera.main;
        Vector3 topRightScreen = new Vector3(Screen.width, Screen.height, cam.nearClipPlane);
        Vector3 topRightWorld = cam.ScreenToWorldPoint(topRightScreen);
        topRightWorld.z = 0; // z���W��0�ɐݒ肵��2D���ʏ�ɌŒ�
        return topRightWorld;
    }

    // ��莞�Ԍ�Ƀv���n�u�����̈ʒu�ɖ߂��R���[�`��
    private IEnumerator ResetPositionAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // �v���n�u�����̈ʒu�ɖ߂�
        if (currentInstance != null)
        {
            currentInstance.transform.position = GetTopRightPosition();

            // Collider2D�R���|�[�l���g�𖳌���
            if (currentCollider != null)
            {
                currentCollider.enabled = false;
            }
        }
    }

    // �v���n�u���폜����֐�
    public void DestroyCurrentInstance()
    {
        if (currentInstance != null)
        {
            Destroy(currentInstance);
            currentInstance = null;
            currentCollider = null;
        }
    }
}


