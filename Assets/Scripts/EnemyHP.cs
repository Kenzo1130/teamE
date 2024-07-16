using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public HealthGauge healthGauge;

    // �G���^����_���[�W�ʁi�G�̏ꍇ�j
    public float Emdamage = 10f;

    // ���̃L�����N�^�[���G���ǂ���
    public string bulletTag = "Bullet";
    public string reflectorg = "Reflector";

    // �c��HP�ɂ����鐔
    public float EmdamageMultiplier = 1.5f;

    // �A�C�e���̃v���n�u�z��
    public GameObject[] itemPrefabs;

    // �A�C�e�����h���b�v����m��
    public float dropProbability = 0.5f;

    // �����X�s�[�h
    public float dropSpeed = 5f;

    // Animator��ǉ�
    public Animator animator;

    // ���̂��������Ƃ��ɉ��Z����X�R�A
    public int scoreValue = 10;


    private void Start()
    {
        currentHP = maxHP;
        healthGauge.SetHP(currentHP, maxHP);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �G���v���C���[�Ƀ_���[�W��^����
        if (collision.gameObject.CompareTag(bulletTag))
        {
            TakeDamage(Emdamage);
        }
        else if (collision.gameObject.CompareTag(reflectorg))
        {
            // Blet�^�O�̕��̂Ƃ̏Փˎ��ɂ͉������Ȃ�
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

        // �X�R�A�����Z
        ScoreManager.instance.AddScore(scoreValue);

        // 1�b��ɃI�u�W�F�N�g��j��
        Destroy(gameObject, 1f);

        // �A�C�e���𗎉�������
        TryDropItem();
    }

    void PlaySpecialDieAnimation()
    {
        // ���ʂȎ��S���[�V����
        //animator.SetTrigger("Explode");

        // �X�R�A�����Z
        ScoreManager.instance.AddScore(scoreValue);

        // 1�b��ɃI�u�W�F�N�g��j��
        Destroy(gameObject, 1f);

        // �A�C�e���𗎉�������
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
