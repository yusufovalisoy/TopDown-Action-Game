using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Fire Settings")]
    public float bulletSpeed = 30f;
    public float fireRate = 0.2f;
    public float range = 200f;
    public int bulletDamage = 25;
    public bool canShoot = true;

    private float nextFireTime;
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleFire();
    }

    void HandleFire()
    {
        if(!canShoot) return;
        if (!Input.GetMouseButton(0)) return;
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        Shoot();
    }

    void Shoot()
    {
        if (mainCamera == null || firePoint == null || bulletPrefab == null) return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, range))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * range;
        }

        Vector3 direction = (targetPoint - firePoint.position).normalized;

        GameObject bulletObject = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.LookRotation(direction)
        );

        Rigidbody bulletRb = bulletObject.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = direction * bulletSpeed;
        }

        BulletManagement bullet = bulletObject.GetComponent<BulletManagement>();
        if (bullet != null)
        {
            bullet.SetDamage(bulletDamage);
        }
    }
}