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
            Vector3 direction = player.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (direction.x > 0 && transform.localScale.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0 && transform.localScale.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBeingDestroyed) return;

        if (collision.gameObject.CompareTag("Player"))
        {                      
            Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
            float knockbackDistance = 1.5f;
            float knockbackDuration = 0.2f;

            collision.gameObject.GetComponent<Player>().ReceiveKnockback(knockbackDir, knockbackDistance, knockbackDuration);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBeingDestroyed) return;

        if (collision.gameObject.CompareTag("Punch"))
        {
            isBeingDestroyed = true;

            ScoreManager.Instance.AddScore(100);

            transform.DOScale(transform.localScale * scaleOnHit, scaleTime).OnComplete(() => Destroy(gameObject));
            AudioManager.instance.PlaySFX(1);
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