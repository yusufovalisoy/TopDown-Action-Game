using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    private bool isDead = false;

    private EnemySpider enemySpider;
    private EnemyManager enemyManager;

    void Awake()
    {
        currentHealth = maxHealth;
        enemySpider = GetComponent<EnemySpider>();

        if (enemySpider != null)
        {
            enemyManager = enemySpider.GetEnemyManager();
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        LevelManager.killedSpider++;

        if (enemyManager == null && enemySpider != null)
        {
            enemyManager = enemySpider.GetEnemyManager();
        }

        if (enemyManager != null && enemySpider != null)
        {
            enemyManager.OnSpiderDied(enemySpider);
        }

        Destroy(gameObject);
    }
}