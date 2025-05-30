using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float shootDuration = 10f;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        float elapsed = 0f;

        while (elapsed < shootDuration)
        {
            Shoot6Directions();
            yield return new WaitForSeconds(shootInterval);
            elapsed += shootInterval;
        }
    }

    private void Shoot6Directions()
    {
        float[] angles = { 240, 255, 270, 285, 300, 315 };

        foreach (float angle in angles)
        {
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = dir * bulletSpeed;
        }
    }
}
