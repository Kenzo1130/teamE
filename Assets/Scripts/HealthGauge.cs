using UnityEngine;
using UnityEngine.UI;

public class HealthGaugear : MonoBehaviour
{
    public Transform target; // HP�o�[��\������Ώۂ�Transform
    public Vector3 offset; // �Ώۂ̓����HP�o�[��\�����邽�߂̃I�t�Z�b�g
    public Image foregroundImage; // HP�o�[�̑O�i��Image

    private void Update()
    {
        // HP�o�[��Ώۂ̓���Ɉʒu������
        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }

    // HP��ݒ肷�郁�\�b�h
    public void SetHP(float currentHP, float maxHP)
    {
        // Image Type��Filled�̏ꍇ�AfillAmount���g�p����HP�o�[���X�V����
        foregroundImage.fillAmount = currentHP / maxHP;
    }
}
