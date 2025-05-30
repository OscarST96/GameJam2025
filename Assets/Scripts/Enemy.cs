using UnityEngine;
using DG.Tweening;

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

    private void Start()
    {
        assignedColorSO = Random.value > 0.5f ? whiteSO : blackSO;
        spriteRenderer.color = assignedColorSO.currentColor;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.DOScale(transform.localScale * scaleOnHit, scaleTime)
                     .OnComplete(() => Destroy(gameObject));
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
