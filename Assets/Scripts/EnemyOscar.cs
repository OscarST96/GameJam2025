using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyOscar : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float targetDistance = 5f;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float push = 1;
    [SerializeField] private PlayerExamplo targetPlayer;
    [SerializeField] private bool OnFollow = false; 
    [SerializeField] private bool OnFollowDistance = false;
    [SerializeField] private Arrow proyectil;//Asignar en el inspector.

    private float currentTimeAttack = 0;
    private Rigidbody2D rb2D;
    private bool attackDistance;
    private bool attack;
    private bool isMovement;
    
    private void Start()
    {
        targetPlayer = FindFirstObjectByType<PlayerExamplo>(); 
        rb2D = GetComponent<Rigidbody2D>();
        isMovement = true;
    }
    private void Update()
    {
        currentTimeAttack += Time.deltaTime;
        if (currentTimeAttack >= attackSpeed)
        {
            currentTimeAttack = 0;
            if (attackDistance)
            {
                OnAttackDistance();
            }
        }
    }
    private void FixedUpdate()
    {
        if (OnFollow)
        {
            Follow();
        }
        if (OnFollowDistance)
        {
            FollowGoalkeeper();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        attack = false;
        if (collision.collider.tag == "Player")
        {
            attack = true;
            Attack();
            Vector2 pushDirection = transform.right.normalized;
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            if (!targetPlayer.isAttack)
            {
                if (playerRb != null)
                {
                    playerRb.AddForce(pushDirection * push, ForceMode2D.Impulse);
                    Debug.Log("Colisión con Player, empujando");
                    
                    Invoke("TargetSpeedZero", 0.5f);
                }
            }
        }
    }
    #region Metodos de Comportamiento de Dezplazamiento
    private void Follow()
    {
        if (isMovement)
        {
            Vector2 direction = (targetPlayer.transform.position - transform.position).normalized;
            rb2D.linearVelocity = direction * velocity;
        }
    }
    private void FollowGoalkeeper()
    {
        Vector2 direction = targetPlayer.transform.position - transform.position;  // Vector hacia el objetivo
        float distance = direction.magnitude;

        if (distance > targetDistance)
        {
            attackDistance = false;
            direction.Normalize(); // Solo la dirección (vector unitario)

            //reducir velocidad conforme se acerca (ejemplo lineal)
            float speed = Mathf.Min(velocity, distance);

            rb2D.linearVelocity = direction * speed;
        }
        else
        {
            rb2D.linearVelocity = Vector3.zero; // Para cuando ya está lo suficientemente cerca
            attackDistance = true;
        }
    }
    #endregion

    #region Metodos de Comportamiento de Ataque
    private void Attack()
    {
        if (attack)
        {
            isMovement = false;
        }
    }
    private void OnAttackDistance()
    {
        if (attackDistance)
        {
            Instantiate(proyectil.gameObject, transform.position, Quaternion.identity);
        }
    }
    #endregion
    public void SpeedZero()
    {
        rb2D.linearVelocity = Vector2.zero;
    }
    public void TargetSpeedZero()
    {
        targetPlayer.SpeedZero();
    }
}
