using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public HealthGauge healthGauge;
    public float Emdamage = 10f;              // �G���^����_���[�W�ʁi�G�̏ꍇ�j
    public string targetag = "target";      // ���̃L�����N�^�[���G���ǂ���
    public float EmdamageMultiplier = 1.5f;   // �c��HP�ɂ����鐔
    public GameObject[] itemPrefabs;        // �A�C�e���̃v���n�u�z��
    public float dropProbability = 0.5f;    // �A�C�e�����h���b�v����m��
    public float dropSpeed = 5f;            // �����X�s�[�h
    public Animator animator;               // Animator��ǉ�


    private void Start()
    {
        currentHP = maxHP;
        healthGauge.SetHP(currentHP, maxHP);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �G���v���C���[�Ƀ_���[�W��^����
        if (collision.gameObject.CompareTag(targetag))
        {
            TakeDamage(Emdamage);
        }
    }
    public void TakeDamage(float Emdamage)
    {
        currentHP -= Emdamage;
        healthGauge.SetHP(currentHP, maxHP);
        // �c��HP�ɂ����鐔���v�Z
        int thresholdDamage = Mathf.FloorToInt(currentHP * EmdamageMultiplier);

        if (currentHP <= 0 && Emdamage > thresholdDamage)
        {
            // �傫�ȃ_���[�W���󂯂��Ƃ��̏���
            PlaySpecialDieAnimation();
        }
        else if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // �ʏ�̎��S���[�V����
        //animator.SetTrigger("Die");

        // �A�C�e���𗎉�������
        Destroy(gameObject,1f);
        TryDropItem();
    }

    void PlaySpecialDieAnimation()
    {
        //animator.SetTrigger("Explode");
        Destroy(gameObject,1f);
        TryDropItem();
        
    }

    void TryDropItem()
    {
        // �m���Ɋ�Â��ăA�C�e�����h���b�v
        if (Random.value < dropProbability)
        {
            // �����_���ȃA�C�e����I��
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject item = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = new Vector2(0, -dropSpeed); // �������ɗ���
            }
        }
    }

}
