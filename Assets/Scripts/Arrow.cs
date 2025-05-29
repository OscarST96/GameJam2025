using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float timeDuraction;

    private Rigidbody2D rb2D;
    private Player directionPlayer;
    private Vector2 direction;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        directionPlayer = FindFirstObjectByType<Player>();
        direction = (directionPlayer.transform.position - transform.position).normalized;
        Destroy(this.gameObject, timeDuraction);
    }
    private void FixedUpdate()
    {
        rb2D.linearVelocity = direction * velocity;
    }
}
