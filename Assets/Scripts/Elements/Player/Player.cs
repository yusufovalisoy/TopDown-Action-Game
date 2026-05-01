using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;

    private Animator animator;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public bool isDead;
    public float damageCooldown = 0.05f;

    private float nextDamageTime = 0f;
    public TMP_Text healthText;
    public GameObject restartButton;

    void Awake()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();
        UpdateHealthUI();
        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }
    }
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHp -= damage;
        UpdateHealthUI();

        if (animator != null)
        {
            animator.SetInteger("DamageID", Random.Range(0, 3));
            animator.SetTrigger("Damage");
        }

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        if (isDead) return;
        isDead = true;
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
        }
        if (playerCombat != null)
        {
            playerCombat.canShoot = false;
            playerCombat.enabled = false;
        }
        if (animator != null)
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Damage");
            animator.ResetTrigger("Jump");
            animator.SetFloat("Speed", 0f);
            animator.SetBool("Aiming", false);
            animator.SetTrigger("Death");
        }
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

    }
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHp;

            float healthPercent = (float)currentHp / maxHp;

            if (healthPercent > 0.6f)
            {
                healthText.color = Color.green;
            }
            else if (healthPercent > 0.3f)
            {
                healthText.color = Color.yellow;
            }
            else
            {
                healthText.color = Color.red;
            }
        }
    } 
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }   
}
