using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float scaleOnHit = 2f;
    [SerializeField] private float scaleTime;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private ColorsSO whiteSO;
    [SerializeField] private ColorsSO blackSO;

    private ColorsSO assignedColorSO;
    private bool isBeingDestroyed = false;

    private void Start()
    {
        assignedColorSO = Random.value > 0.5f ? whiteSO : blackSO;
        spriteRenderer.color = assignedColorSO.currentColor;
    }
    private void Update()
    {
        if (player != null && !isBeingDestroyed)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBeingDestroyed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Golpeó al jugador");

            Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
            float knockbackDistance = 1.5f;
            float knockbackDuration = 0.2f;

            collision.gameObject.GetComponent<Player>().ReceiveKnockback(knockbackDir, knockbackDistance, knockbackDuration);

            isBeingDestroyed = true;
            transform.DOScale(transform.localScale * scaleOnHit, scaleTime).OnComplete(() => Destroy(gameObject));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBeingDestroyed) return;

        if (collision.gameObject.CompareTag("Punch"))
        {
            Debug.Log("puñetazo");
            isBeingDestroyed = true;

            ScoreManager.Instance.AddScore(1000);

            Destroy(gameObject);
        }
    }
    public void Init(Transform target)
    {
        player = target;
    }
    public Color GetCurrentColor()
    {
        return assignedColorSO.currentColor;
    }
}