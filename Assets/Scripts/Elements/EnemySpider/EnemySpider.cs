using UnityEngine;
using UnityEngine.AI;

public class EnemySpider : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Player _playerHealth;
    private EnemyManager _enemyManager;

    private NavMeshAgent _agent;
    private Rigidbody _rb;

    public float damageDistance = 1.5f;
    public int contactDamage = 10;
    public float damageCooldown = 1f;

    private float nextDamageTime = 0f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();

        if (_rb != null)
        {
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }
    }

    public void StartEnemy(PlayerMovement playerMovement, EnemyManager enemyManager)
    {
        _playerMovement = playerMovement;
        _enemyManager = enemyManager;

        if (_playerMovement != null)
        {
            _playerHealth = _playerMovement.GetComponent<Player>();
        }
    }

    public EnemyManager GetEnemyManager()
    {
        return _enemyManager;
    }

    private void Update()
    {
        if (_playerMovement == null || _agent == null) return;
        if (!_agent.isActiveAndEnabled || !_agent.isOnNavMesh) return;

        _agent.SetDestination(_playerMovement.transform.position);

        TryDamagePlayer();
    }

    private void TryDamagePlayer()
    {
        if (_playerHealth == null) return;
        if (_playerHealth.isDead) return;
        if (Time.time < nextDamageTime) return;

        float distance = Vector3.Distance(transform.position, _playerMovement.transform.position);

        if (distance <= damageDistance)
        {
            _playerHealth.TakeDamage(contactDamage);
            nextDamageTime = Time.time + damageCooldown;
        }
    }
}
