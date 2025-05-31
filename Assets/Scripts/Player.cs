using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    private Rigidbody2D RigidBody2D;
    [SerializeField] private float speed = 5f;
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

    private Animator animator;
    private bool isAttacking = false;
    private bool isKnockedBack = false;

    [SerializeField] private float invulnerableTime = 1f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private SpriteRenderer aura;
    private bool isInvulnerable = false;

    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        aura.color = colorData.currentColor;
    }

    private void Update()
    {
        if (!isKnockedBack)
        {
            RigidBody2D.linearVelocity = new Vector2(direction.x * speed, RigidBody2D.linearVelocity.y);
        }

        if (direction.x > 0 && !isAttacking)
        {
            facingRight = true;
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && !isAttacking)
        {
            facingRight = false;
            spriteRenderer.flipX = true;
        }

        animator.SetBool("Run", direction.x != 0);
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
            animator.SetBool("Jump", false);
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
        if (isGrounded && !isKnockedBack)
        {
            RigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("Jump", true);
        }
    }
    public void OnChangeColor()
    {
        colorData.currentColor = (colorData.currentColor == Color.white) ? Color.black : Color.white;
        aura.color = colorData.currentColor;
    }
    private void OnAttack()
    {
        attackScript.DoAttack(facingRight);
        if (!isAttacking)
        {
            StartCoroutine(PlayAnimationAndWait("Attack"));
        }
    }
    public IEnumerator PlayAnimationAndWait(string animationName)
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        speed = 0f;

        yield return new WaitForSeconds(0.5f);

        speed = 5f;
        isAttacking = false;
        animator.SetBool("Attack", false);
    }

    public void ReceiveKnockback(Vector2 direction, float distance, float duration)
    {
        if (isInvulnerable) return;

        isKnockedBack = true;
        isInvulnerable = true;
        RigidBody2D.linearVelocity = Vector2.zero;

        StartCoroutine(Blinking());

        transform.DOMove((Vector2)transform.position + direction * distance, duration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                isKnockedBack = false;
            });
    }
    private IEnumerator Blinking()
    {
        float elapsed = 0f;
        while (elapsed < invulnerableTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }
        spriteRenderer.enabled = true;
        isInvulnerable = false;
    }
}
