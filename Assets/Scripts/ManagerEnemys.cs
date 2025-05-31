using UnityEngine;

public class ManagerEnemys : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private Transform player;

    [Header("ENEMY 1 - Spawner 1")]
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private Transform spawnPoint1;

    [Header("ENEMY 1 - Spawner 2")]
    [SerializeField] private Transform spawnPoint1_2;

    [Header("ENEMY 2 Shooter")]
    [SerializeField] private GameObject enemyShooterPrefab2;
    [SerializeField] private Transform spawnPoint2;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy1_FromSpawner1), 0f, 4f);

        InvokeRepeating(nameof(SpawnEnemy1_FromSpawner2), 2f, 5f);

        Invoke(nameof(SpawnEnemy2Shooter), 3f);
    }

    public void SpawnEnemy1_FromSpawner1()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab1, spawnPoint1.position, Quaternion.identity);
        Enemy followScript = enemyInstance.GetComponent<Enemy>();
        if (followScript != null)
        {
            followScript.Init(player);
        }
    }

    public void SpawnEnemy1_FromSpawner2()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab1, spawnPoint1_2.position, Quaternion.identity);
        Enemy followScript = enemyInstance.GetComponent<Enemy>();
        if (followScript != null)
        {
            followScript.Init(player);
        }
    }

    public void SpawnEnemy2Shooter()
    {
        Instantiate(enemyShooterPrefab2, spawnPoint2.position, Quaternion.identity);
    }
}
