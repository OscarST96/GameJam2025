using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
   [SerializeField] private int whiteLife = 5;
   [SerializeField] private int blackLife = 5;
   [SerializeField] private const int maxLife = 10;
   [SerializeField] private const int minLife = 0;

    [SerializeField] private ColorsSO playerColor;

    [SerializeField] private Image whiteLifeBar;
    [SerializeField] private Image blackLifeBar;
    private void Start()
    {
        UpdateLifeBars();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy == null) return;

            Color enemyColor = enemy.GetCurrentColor();
            Color playerCurrentColor = playerColor.currentColor;

            if (playerCurrentColor == Color.white)
            {
                whiteLife = whiteLife + 1;
                blackLife = blackLife - 1;
            }
            else if (playerCurrentColor == Color.black)
            {
                blackLife = blackLife + 1;
                whiteLife = whiteLife - 1;
            }
            UpdateLifeBars();

            if (whiteLife >= maxLife || blackLife >= maxLife)
            {
                SceneManager.LoadScene("YouLoose");
            }
        }
    }
    public int GetWhiteLife()
    {
        return whiteLife;
    }

    public int GetBlackLife()
    {
        return blackLife;
    }
    private void UpdateLifeBars()
    {
        whiteLifeBar.fillAmount = (float)whiteLife / maxLife;
        blackLifeBar.fillAmount = (float)blackLife / maxLife;
    }
    public void IncreaseWhiteLife()
    {
        whiteLife = Mathf.Clamp(whiteLife + 1, minLife, maxLife);
        CheckLoseCondition();
        UpdateLifeBars();
    }

    public void DecreaseBlackLife()
    {
        blackLife = Mathf.Clamp(blackLife - 1, minLife, maxLife);
        UpdateLifeBars();
    }

    public void IncreaseBlackLife()
    {
        blackLife = Mathf.Clamp(blackLife + 1, minLife, maxLife);
        CheckLoseCondition();
        UpdateLifeBars();
    }

    public void DecreaseWhiteLife()
    {
        whiteLife = Mathf.Clamp(whiteLife - 1, minLife, maxLife);
        UpdateLifeBars();
    }

    public Color GetCurrentColor()
    {
        return playerColor.currentColor;
    }

    private void CheckLoseCondition()
    {
        if (whiteLife >= maxLife || blackLife >= maxLife)
        {
            SceneManager.LoadScene("YouLoose");
        }
    }

}
