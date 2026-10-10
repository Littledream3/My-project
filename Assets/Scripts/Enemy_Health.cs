using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public int ExpReward=3;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;

        }
        else if (currentHealth <= 0)
        {
            OnMonsterDefeated(ExpReward);
            Destroy(gameObject);
        }
    }
}
