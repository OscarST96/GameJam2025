using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    private Rigidbody2D RigidBody2D;
    [SerializeField] private float velocity = 5f;
    private Vector2 direction;

    [Header("Salto")]
    [SerializeField] private float JumpForce;
    private bool isGrounded = false;

    [Header("Color")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ColorsSO colorData;

    [Header("Ataque")]
    [SerializeField] private Attack attackScript;
    private bool facingRight = true;
    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        InputReader.OnMove += OnMove;
        InputReader.OnJump += OnJump;
        InputReader.OnChangeColor += OnChangeColor;
        InputReader.OnAttack += OnAttack;

    }
    private void OnDisable()
    {
        InputReader.OnMove -= OnMove;
        InputReader.OnJump -= OnJump;
        InputReader.OnChangeColor -= OnChangeColor;
        InputReader.OnAttack -= OnAttack;

    }
    private void Start()
    {
        spriteRenderer.color = colorData.currentColor;
    }
    private void Update()
    {
        RigidBody2D.linearVelocity = new Vector2(direction.x * velocity, RigidBody2D.linearVelocity.y);

        if (direction.x > 0) facingRight = true;
        else if (direction.x < 0) facingRight = false;
    }
    private void OnMove(Vector2 inputDirection)
    {
        direction = inputDirection;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    public void OnJump()
    {
        if (isGrounded)
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    public void OnChangeColor()
    {
        if (colorData.currentColor == Color.white)
            colorData.currentColor = Color.black;
        else
            colorData.currentColor = Color.white;

        spriteRenderer.color = colorData.currentColor;
    }
    private void OnAttack()
    {
        attackScript.DoAttack(facingRight);
    }

}
