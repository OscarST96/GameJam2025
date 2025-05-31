using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootInterval = 2f;

    [Header("Movement Settings")]
    [SerializeField] private float minX = -8.10f;
    [SerializeField] private float maxX = 8.20f;
    [SerializeField] private float baseSpeed = 2f;

    [Header("Timer Settings")]
    [SerializeField] private float enemyLifetime;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI timerText;

    private float moveDirection = 1f;
    private float elapsed;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private void Update()
    {
        elapsed += Time.deltaTime;

        if (timerText != null)
            timerText.text = "Tiempo: " + elapsed.ToString("F1") + "s";

        float currentSpeed = baseSpeed;
        if (elapsed >= 10f)
        {
            currentSpeed *= 2.5f;
        }

        transform.position += new Vector3(moveDirection * currentSpeed * Time.deltaTime, 0f, 0f);

        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            moveDirection = 1f;
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            moveDirection = -1f;
        }

        if (elapsed >= enemyLifetime)
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    private IEnumerator ShootingRoutine()
    {
        while (elapsed < enemyLifetime)
        {
            ShootBullets();
            yield return new WaitForSeconds(shootInterval);
        }
    }
    private void ShootBullets()
    {
        float[] angles = { 210, 220, 230, 240, 250, 260, 270, 280, 290, 300, 310 };

        foreach (float angle in angles)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
            Vector2 offset = dir * 0.2f;

            GameObject bullet = Instantiate(bulletPrefab, (Vector2)transform.position + offset, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float randomSpeed = Random.Range(5f, 10f);
            rb.linearVelocity = dir * randomSpeed;

            SpriteRenderer sr = bullet.GetComponent<SpriteRenderer>();

            sr.color = new Color(Random.value, Random.value, Random.value);

            Debug.Log("Velocidad de bala: " + randomSpeed);
        }
    }
}
