using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float targetDistance = 5f;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private Player targetPlayer;
    [SerializeField] private bool OnFollow = false; 
    [SerializeField] private bool OnFollowDistance = false;
    [SerializeField] private Arrow proyectil;//Asignar en el inspector.

    private float currentTimeAttack = 0;
    private Rigidbody2D rb2D;
    private bool attackDistance;
    
    private void Start()
    {
        targetPlayer = FindFirstObjectByType<Player>();
        rb2D = GetComponent<Rigidbody2D>();
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
    #region Metodos de Comportamiento de Dezplazamiento
    private void Follow()
    {
        Vector2 direction = (targetPlayer.transform.position - transform.position).normalized;
        rb2D.linearVelocity = direction * velocity;
    }
    private void FollowGoalkeeper()
    {
        Vector3 direction = targetPlayer.transform.position - transform.position;  // Vector hacia el objetivo
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
    private void OnAttackDistance()
    {
        if (attackDistance)
        {
            Instantiate(proyectil.gameObject, transform.position, Quaternion.identity);
        }
    }
    #endregion
}
