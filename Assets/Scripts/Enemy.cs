using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ColorsSO colorData;

    private void Start()
    {
        colorData.currentColor = Random.value > 0.5f ? Color.white : Color.black;

        spriteRenderer.color = colorData.currentColor;
    }
}
