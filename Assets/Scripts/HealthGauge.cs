using UnityEngine;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] Transform target; // HPバーを表示する対象のTransform
    public Vector3 offset; // 対象の頭上にHPバーを表示するためのオフセット
    public Image foregroundImage; // HPバーの前景のImage
    public Transform cam; // カメラのTransform

    private void Update()
    {
        // HPバーを対象の頭上に位置させる
        if (target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
        }
        else
        {
            Destroy(gameObject); // 対象が消えたらHPバーも消す
        }
    }

    // HPを設定するメソッド
    public void SetHP(float currentHP, float maxHP)
    {
        foregroundImage.fillAmount = currentHP / maxHP;
    }
}
