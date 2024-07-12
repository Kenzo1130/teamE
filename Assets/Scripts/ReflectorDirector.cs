using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    public GameObject prefab;   // �g�p����v���n�u
    public Vector3 initialPosition = new Vector3(1.0f, 1.0f, 0); // �C�ӂ̏����ʒu
    public float resetTime = 3.0f;   // ���Z�b�g�܂ł̎���
    public float destroyTime = 5.0f; // �v���n�u��������܂ł̎���
    public string targetTag = "Target";   // �ՓˑΏۂ̃^�O
    public string enemyTag = "Enemy";     // �G�̃^�O
    public string bletTag = "Blet";       // ��������^�O

    private GameObject currentInstance;   // ���݂̃v���n�u�C���X�^���X
    private bool isMouseDown = false;   // �}�E�X��������Ă��邩�ǂ���
    private bool isWaiting = false;   // �ꎞ��~�����ǂ���
    private Collider2D currentCollider;   // ���݂̃v���n�u�̃R���C�_�[

    void Start()
    {
        // �v���n�u�̃C���X�^���X��C�ӂ̏����ʒu�ɔz�u
        CreateInstanceAtInitialPosition();
    }

    void Update()
    {
        if (isWaiting)
        {
            // �ꎞ��~���̓}�E�X�̓����ɔ������Ȃ�
            return;
        }

        if (isMouseDown && Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z���W��0�ɐݒ肵��2D���ʏ�ɌŒ�

            // �v���n�u�̈ʒu���}�E�X�̈ʒu�ɐݒ�
            currentInstance.transform.position = mousePosition;
        }
        else if (isMouseDown && Input.GetMouseButtonUp(0))
        {
            // �}�E�X�̍��{�^���������ꂽ��
            isMouseDown = false;

            // �R���C�_�[��L����
            if (currentCollider != null)
            {
                currentCollider.enabled = true;
            }

            // �v���n�u����莞�Ԍ�ɏ�������R���[�`�����J�n
            StartCoroutine(DestroyInstanceAfterTime(destroyTime));

            // �R���C�_�[�L�����O�̏Փ˃`�F�b�N�R���[�`�����J�n
            StartCoroutine(CheckForCollisionBeforeEnableCollider());

            // �v���n�u�����Z�b�g����R���[�`�����J�n
            StartCoroutine(ResetPositionAfterTime(resetTime));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            // �}�E�X�̍��{�^���������ꂽ��
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z���W��0�ɐݒ肵��2D���ʏ�ɌŒ�

            // �}�E�X�ʒu���v���n�u�͈͓̔��ɂ���ꍇ�̂ݔ���
            if (currentCollider != null && currentCollider.OverlapPoint(mousePosition))
            {
                isMouseDown = true;
                currentCollider.enabled = false; // �}�E�X�Ŏ����Ă���Ԃ̓R���C�_�[�𖳌���
            }
        }
    }

    // �v���n�u�̃C���X�^���X��C�ӂ̏����ʒu�ɔz�u����֐�
    private void CreateInstanceAtInitialPosition()
    {
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = initialPosition;
        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            currentCollider.enabled = true; // ������ԂŃR���C�_�[��L����
        }

        // �Փˏ�����S������R���|�[�l���g��ǉ�
        ReflectorController collisionHandler = currentInstance.AddComponent<ReflectorController>();
        collisionHandler.Initialize(this, targetTag, enemyTag, bletTag);
    }

    // ��莞�Ԍ�Ƀv���n�u�����̈ʒu�ɖ߂��R���[�`��
    private IEnumerator ResetPositionAfterTime(float time)
    {
        isWaiting = true;
        yield return new WaitForSeconds(time);
        isWaiting = false;

        // �v���n�u�����̈ʒu�ɖ߂�
        if (currentInstance != null)
        {
            currentInstance.transform.position = initialPosition;

            // �R���C�_�[��L����
            if (currentCollider != null)
            {
                currentCollider.enabled = true;
            }
        }
    }

    // �R���C�_�[��L��������O�ɏՓ˃`�F�b�N���s���R���[�`��
    private IEnumerator CheckForCollisionBeforeEnableCollider()
    {
        yield return new WaitForEndOfFrame();

        if (currentInstance != null && currentCollider != null)
        {
            // �v���n�u��Bounds���擾
            Bounds bounds = currentCollider.bounds;

            // �v���n�u��Bounds��OverlapBox�����s
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(targetTag) || hitCollider.CompareTag(enemyTag))
                {
                    DestroyCurrentInstance();
                    yield break;
                }
            }

            currentCollider.enabled = true;
        }
    }

    // ��莞�Ԍ�Ƀv���n�u���폜���A�V�����C���X�^���X�𐶐�����R���[�`��
    private IEnumerator DestroyInstanceAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // ���݂̃v���n�u���폜
        DestroyCurrentInstance();

        // �V�����v���n�u�̃C���X�^���X��C�ӂ̏����ʒu�ɐ���
        CreateInstanceAtInitialPosition();
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
