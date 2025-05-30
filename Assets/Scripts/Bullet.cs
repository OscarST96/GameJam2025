using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ColorsSO whiteSO;
    [SerializeField] private ColorsSO blackSO;

    private ColorsSO assignedColorSO;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        assignedColorSO = Random.value > 0.5f ? whiteSO : blackSO;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = assignedColorSO.currentColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.collider.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                Color playerColor = playerLife.GetCurrentColor(); 
                Color bulletColor = assignedColorSO.currentColor;

                if (playerColor == Color.white && bulletColor == Color.white)
                {
                    playerLife.IncreaseWhiteLife();
                    playerLife.DecreaseBlackLife();
                }
                else if (playerColor == Color.black && bulletColor == Color.black)
                {
                    playerLife.IncreaseBlackLife();
                    playerLife.DecreaseWhiteLife();
                }
            }

            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
