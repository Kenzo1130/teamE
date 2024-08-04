using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorDirector : MonoBehaviour
{
    public GameObject[] prefabs;   // �g�p����v���n�u�̃��X�g
    public Vector3 initialPosition = new Vector3(1.0f, 1.0f, 0); // �C�ӂ̏����ʒu
    public float resetTime = 3.0f;   // ���Z�b�g�܂ł̎���
    public float destroyTime = 5.0f; // �v���n�u��������܂ł̎���
    public string EnemyTag = "Enemy";   // �ՓˑΏۂ̃^�O
    public string bullet = "Bullet";       // ��������^�O
    public string spbullet = "SpBullet";       // ��������^�O
    public Rect validArea;    // �C�ӂ͈̔�
    public Vector2 initialColliderSize = new Vector2(1.0f, 1.0f); // �������̃R���C�_�[�̃T�C�Y
    public Vector2 releaseColliderSize = new Vector2(0.5f, 0.5f); // �����ꂽ���̃R���C�_�[�̃T�C�Y


    private GameObject currentInstance;   // ���݂̃v���n�u�C���X�^���X
    private bool isMouseDown = false;   // �}�E�X��������Ă��邩�ǂ���
    private bool isWaiting = false;   // �ꎞ��~�����ǂ���
    private Collider2D currentCollider;   // ���݂̃v���n�u�̃R���C�_�[

    public AudioClip SEspawn;
    public AudioClip collisionEnemy;
    public AudioClip collisionBullet;
    AudioSource audioSource;

    PlayerLife playerLife;

    int life;

    void Start()
    {
        playerLife = FindObjectOfType<PlayerLife>();
        audioSource = GetComponent<AudioSource>();
        // �v���n�u�̃C���X�^���X��C�ӂ̏����ʒu�ɔz�u
        CreateInstanceAtInitialPosition();
    }

    void Update()
    {
        life = playerLife.lifea(life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }

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
                SetColliderSize(currentCollider, releaseColliderSize); // �����ꂽ�Ƃ��̃R���C�_�[�T�C�Y��ݒ�
                currentCollider.enabled = true;
            }

            // �͈͓��`�F�b�N���s���A�͈͊O�Ȃ珉���ʒu�ɖ߂�
            if (!IsWithinValidArea(currentInstance.transform.position))
            {
                StartCoroutine(ResetPositionAfterTime(0));  // �����ɏ����ʒu�ɖ߂�
            }
            else
            {
                // �v���n�u����莞�Ԍ�ɏ�������R���[�`�����J�n
                StartCoroutine(DestroyInstanceAfterTime(destroyTime));

                // �R���C�_�[�L�����O�̏Փ˃`�F�b�N�R���[�`�����J�n
                StartCoroutine(CheckForCollisionBeforeEnableCollider());

                // �v���n�u�����Z�b�g����R���[�`�����J�n
                StartCoroutine(ResetPositionAfterTime(resetTime));
            }

            audioSource.PlayOneShot(SEspawn); // �}�E�X�������ꂽ�Ƃ��̃T�E���h�Đ�
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
        if (prefabs.Length == 0) return;

        // �����_���Ƀv���n�u��I��
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        currentInstance = Instantiate(prefab);
        currentInstance.transform.position = initialPosition;

        // �R���C�_�[��K�؂ȃT�C�Y�ɐݒ�
        SetColliderSize(currentCollider, releaseColliderSize);

        currentCollider = currentInstance.GetComponent<Collider2D>();
        if (currentCollider != null)
        {
            // �������̃R���C�_�[�T�C�Y��ݒ�
            SetColliderSize(currentCollider, initialColliderSize);
            currentCollider.enabled = true; // ������ԂŃR���C�_�[��L����
        }

        // �Փˏ�����S������R���|�[�l���g��ǉ�
        ReflectorController collisionHandler = currentInstance.AddComponent<ReflectorController>();
        collisionHandler.Initialize(this, EnemyTag, bullet, spbullet, collisionEnemy, collisionBullet, audioSource);
    }

    private void SetColliderSize(Collider2D collider, Vector2 size)
    {

        if (collider is BoxCollider2D boxCollider)
        {
            boxCollider.size = size; // BoxCollider�̃T�C�Y��ݒ�
        }
        else if (collider is CircleCollider2D circleCollider)
        {
            circleCollider.radius = size.x / 2; // CircleCollider�̔��a��ݒ�
        }
        // ���̃R���C�_�[�^�C�v�������Őݒ�ł��܂�

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
                // �����ʒu�ɖ߂��Ƃ��ɃR���C�_�[�T�C�Y�����ɖ߂�
                SetColliderSize(currentCollider, initialColliderSize);
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
                if (hitCollider.CompareTag(EnemyTag))
                {
                    audioSource.PlayOneShot(collisionEnemy);
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

    // ���̂��C�ӂ͈͓̔��ɂ��邩�ǂ������`�F�b�N����֐�
    private bool IsWithinValidArea(Vector3 position)
    {
        return validArea.Contains(new Vector2(position.x, position.y));
    }
}
