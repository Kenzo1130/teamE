using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    // �v���n�u��ݒ�
    public GameObject prefab;
    public float timerMax = 1.0f; // �����Ԋu�i�b�j
    float timer = 0f; // �^�C�}�[

    private GameObject currentInstance;
    private bool isMouseDown = false;
    private Collider2D currentCollider;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            // �}�E�X�̍��{�^����������Ă����
            if (Input.GetMouseButton(0))
            {
                if (currentInstance == null)
                {
                    // �v���n�u�̃C���X�^���X�𐶐�
                    currentInstance = Instantiate(prefab);

                    // �C���X�^���X��Collider2D�R���|�[�l���g���擾���Ė�����
                    currentCollider = currentInstance.GetComponent<Collider2D>();
                    if (currentCollider != null)
                    {
                        currentCollider.enabled = false;
                    }
                }

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

                // �v���n�u�̃C���X�^���X�̎Q�Ƃ��N���A
                currentInstance = null;
                currentCollider = null;
                timer = timerMax;
            }
        }
    }

}
