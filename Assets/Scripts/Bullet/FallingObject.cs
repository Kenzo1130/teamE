using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject risingObjectPrefab; // �㏸����I�u�W�F�N�g�̃v���n�u
    public string targetTag = "Target";   // �Փ˔�����s���^�O
    private float fallSpeed;              // �������x

    void Start()
    {
        // �������x��ݒ�i��F�����_���ȑ��x�j
        fallSpeed = Random.Range(1f, 5f);
    }

    void Update()
    {
        // �I�u�W�F�N�g�����Ɉړ�������
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ���݂̈ʒu�ɐV�����I�u�W�F�N�g�𐶐�
            GameObject newRisingObject = Instantiate(risingObjectPrefab, transform.position, Quaternion.identity);

            // �V�����I�u�W�F�N�g�ɏ㏸�X�N���v�g��ǉ�
            newRisingObject.AddComponent<RisingObject>().riseSpeed = fallSpeed;

            // ���݂̃I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}

