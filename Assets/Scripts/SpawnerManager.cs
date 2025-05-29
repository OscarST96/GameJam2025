using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private float SpawnTime = 5f;
    [SerializeField] private Transform[] spawnPosition;//Asignar en el inspector, posiciones.
    [SerializeField] private Enemy[] enemy;//Asignar en el inspector, enemigos

    private float currentTime = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= SpawnTime)
        {
            SpawnerEnemy();
            currentTime = 0;
        }
    }
    private void SpawnerEnemy()
    {
        int rangeSpawner = Random.Range(0, spawnPosition.Length);
        int EnemySelect = Random.Range(0, enemy.Length);
        switch (rangeSpawner)
        {
            case 0:
                Instantiate(enemy[EnemySelect].gameObject, spawnPosition[rangeSpawner].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemy[EnemySelect].gameObject, spawnPosition[rangeSpawner].transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy[EnemySelect].gameObject, spawnPosition[rangeSpawner].transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy[EnemySelect].gameObject, spawnPosition[rangeSpawner].transform.position, Quaternion.identity);
                break;
        }
    }
}
