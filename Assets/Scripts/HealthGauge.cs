using UnityEngine;
using UnityEngine.UI;

public class HealthGaugear : MonoBehaviour
{
    public Transform target; // HPバーを表示する対象のTransform
    public Vector3 offset; // 対象の頭上にHPバーを表示するためのオフセット
    public Image foregroundImage; // HPバーの前景のImage

    private void Update()
    {
        // HPバーを対象の頭上に位置させる
        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }

    // HPを設定するメソッド
    public void SetHP(float currentHP, float maxHP)
    {
        // Image TypeがFilledの場合、fillAmountを使用してHPバーを更新する
        foregroundImage.fillAmount = currentHP / maxHP;
    }
}
