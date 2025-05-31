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
    private bool isBeingDestroyed = false; // Nueva bandera

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
        if (isBeingDestroyed) return; // Ya está en proceso de destrucción

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("creceeeeee");
            isBeingDestroyed = true;
            transform.DOScale(transform.localScale * scaleOnHit, scaleTime).OnComplete(() => Destroy(gameObject));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBeingDestroyed) return; // Ya está en proceso de destrucción

        if (collision.gameObject.CompareTag("Punch"))
        {
            Debug.Log("puñoooooooooo");
            isBeingDestroyed = true;
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
