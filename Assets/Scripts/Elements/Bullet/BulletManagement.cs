using UnityEngine;

public class BulletManagement : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private float lifeTime = 5f;

    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;
        hasHit = true;

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth == null)
        {
            enemyHealth = other.GetComponentInParent<EnemyHealth>();
        }

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
