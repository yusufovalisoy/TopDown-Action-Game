using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public PlayerMovement player;
    public EnemySpider enemySpiderPrefab;

    public int targetEnemyCount = 25;
    public float spawnDelay = 0.5f;

    public List<EnemySpider> spiderEnemies = new List<EnemySpider>();

    private bool isSpawning = false;

    void Start()
    {
        for (int i = 0; i < targetEnemyCount; i++)
        {
            SpawnEnemySpider();
        }
    }

    public void SpawnEnemySpider()
    {
        float enemyXpos = Random.Range(-12f, 14f);
        float enemyZpos = Random.Range(-20f, 28f);

        EnemySpider newEnemySpider = Instantiate(enemySpiderPrefab);
        newEnemySpider.transform.position = new Vector3(enemyXpos, 0.05f,enemyZpos);

        spiderEnemies.Add(newEnemySpider);
        newEnemySpider.StartEnemy(player, this);
    }

    public void OnSpiderDied(EnemySpider deadSpider)
    {
        if (spiderEnemies.Contains(deadSpider))
        {
            spiderEnemies.Remove(deadSpider);
        }

        if (!isSpawning)
        {
            StartCoroutine(RespawnMissingSpiders());
        }
    }

    private IEnumerator RespawnMissingSpiders()
    {
        isSpawning = true;

        while (spiderEnemies.Count < targetEnemyCount)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnEnemySpider();
        }

        isSpawning = false;
    }
}
