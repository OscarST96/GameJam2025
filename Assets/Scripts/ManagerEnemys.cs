using UnityEngine;

public class ManagerEnemys : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private Transform player;

    [Header("ENEMY 1")]
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private Transform spawnPoint1;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy1", 0f, 4f);
    }

    public void SpawnEnemy1()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab1, spawnPoint1.position, Quaternion.identity);

        Enemy followScript = enemyInstance.GetComponent<Enemy>();
        if (followScript != null)
        {
            followScript.Init(player);
        }
    }
}
