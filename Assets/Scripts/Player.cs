using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAttack;
    public float push;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Vector2 pushDirection = transform.right.normalized;
            Rigidbody2D EnemyRB = collision.collider.GetComponent<Rigidbody2D>();
            if (isAttack)
            {
                if (EnemyRB != null)
                {
                    EnemyRB.AddForce(-pushDirection * push, ForceMode2D.Impulse);
                    Debug.Log("Colisión con Enemy, empujando");
                }
            }
        }
    }
    public void SpeedZero()
    {
        rb2d.linearVelocity = Vector2.zero;
    }
}
