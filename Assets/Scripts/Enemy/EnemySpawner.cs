using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int enemyBase = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeToNextWaves = 5f;
    [SerializeField] private float difficultyScaling = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Events")]
    public static UnityEvent onEnemyDestroyed = new UnityEvent();

    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float timeLastSpawn;
    private float eps;                   
    private bool enemiesSpawned = false;
    private int currentWave = 1;

    private void Awake()
    {
        onEnemyDestroyed.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!enemiesSpawned) return;

        timeLastSpawn += Time.deltaTime;

        if (timeLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.start.position, Quaternion.identity);
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeToNextWaves);
        enemiesSpawned = true;
        enemiesLeftToSpawn = EnemyPerWave();
        eps = EnemiesPerSecond();
    }

    private void EndWave()
    {
        enemiesSpawned = false;
        timeLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private int EnemyPerWave()
    {
        return Mathf.RoundToInt(enemyBase * Mathf.Pow(currentWave, difficultyScaling));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScaling), 0f, enemiesPerSecondCap);
    }

}
