using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private ColorsSO whiteSO;
    [SerializeField] private ColorsSO blackSO;

    private ColorsSO assignedColorSO;

    private void Start()
    {
        assignedColorSO = Random.value > 0.5f ? whiteSO : blackSO;

        spriteRenderer.color = assignedColorSO.currentColor;
    }
    public Color GetCurrentColor()
    {
        return assignedColorSO.currentColor;
    }
}
