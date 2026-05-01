using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;
    public EnemyManager enemyManager;
    public GameObject levelUpDamageObject;
    public GameObject levelUpFireRateObject;
    public GameObject levelUpSpeedObject;
    public GameObject levelCompleted;

    public static int killedSpider = 0;

    private bool levelUpTriggered = false;

    void Start()
    {
        if (levelUpDamageObject != null)
        {
            levelUpDamageObject.SetActive(false);
        }
        if (levelUpFireRateObject != null)
        {
            levelUpFireRateObject.SetActive(false);
        }
        if (levelUpSpeedObject != null)
        {
            levelUpSpeedObject.SetActive(false);
        }
        if(levelCompleted != null)
        {
            levelCompleted.SetActive(false);
        }
    }

    void Update()
    {
        if (!levelUpTriggered && killedSpider == 5)
        {
            levelUpTriggered = true;
            playerCombat.bulletDamage = 30;

            if (levelUpDamageObject != null)
            {
                levelUpDamageObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;
        }
        if (!levelUpTriggered && killedSpider == 15)
        {
            levelUpTriggered = true;
            playerCombat.fireRate = 0.15f;

            if (levelUpFireRateObject != null)
            {
                levelUpFireRateObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;

        }
        if (!levelUpTriggered && killedSpider == 25)
        {
            levelUpTriggered = true;
            playerMovement.walkSpeed = 4f;

            if (levelUpSpeedObject != null)
            {
                levelUpSpeedObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;

        }
        if (!levelUpTriggered && killedSpider == 35)
        {
            levelUpTriggered = true;
            playerCombat.bulletDamage = 40;

            if (levelUpDamageObject != null)
            {
                levelUpDamageObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;
        }
        if (!levelUpTriggered && killedSpider == 45)
        {
            levelUpTriggered = true;
            playerCombat.fireRate = 0.1f;

            if (levelUpFireRateObject != null)
            {
                levelUpFireRateObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;

        }
        if (!levelUpTriggered && killedSpider == 55)
        {
            levelUpTriggered = true;
            playerMovement.walkSpeed = 5f;

            if (levelUpSpeedObject != null)
            {
                levelUpSpeedObject.SetActive(true);
                Invoke(nameof(HideLevelUpText), 2f);
            }
            levelUpTriggered=false;
        }
        if (killedSpider == 75)
        {
            enemyManager.targetEnemyCount = 0;
            foreach (EnemySpider spider in new List<EnemySpider>(enemyManager.spiderEnemies))
            {
                if (spider != null)
                {
                    Destroy(spider.gameObject);
                }
            }
            enemyManager.spiderEnemies.Clear();
            levelCompleted.SetActive(true);
        }
    }

    void HideLevelUpText()
    {
        if (levelUpDamageObject != null)
        {
            levelUpDamageObject.SetActive(false);
        }
        if (levelUpFireRateObject != null)
        {
            levelUpFireRateObject.SetActive(false);
        }
        if (levelUpSpeedObject != null)
        {
            levelUpSpeedObject.SetActive(false);
        }
    }
}
