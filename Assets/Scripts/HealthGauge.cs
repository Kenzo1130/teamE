using UnityEngine;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] Transform target; // HP�o�[��\������Ώۂ�Transform
    public Vector3 offset; // �Ώۂ̓����HP�o�[��\�����邽�߂̃I�t�Z�b�g
    public Image foregroundImage; // HP�o�[�̑O�i��Image
    public Transform cam; // �J������Transform

    private void Update()
    {
        // HP�o�[��Ώۂ̓���Ɉʒu������
        if (target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
        else
        {
            Destroy(gameObject); // �Ώۂ���������HP�o�[������
        }
    }

    // HP��ݒ肷�郁�\�b�h
    public void SetHP(float currentHP, float maxHP)
    {
        foregroundImage.fillAmount = currentHP / maxHP;
    }
}
