using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public HealthGaugear healthGaugear;

    private void Start()
    {
        currentHP = maxHP;
        healthGaugear.SetHP(currentHP, maxHP);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;
        healthGaugear.SetHP(currentHP, maxHP);
    }

    public void Heal(float healAmount)
    {
        currentHP += healAmount;
        if (currentHP > maxHP) currentHP = maxHP;
        healthGaugear.SetHP(currentHP, maxHP);
    }
}
