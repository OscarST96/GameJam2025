using DG.Tweening;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private GameObject attackGO;
    [SerializeField] private float attackScale = 2f;
    [SerializeField] private float attackDuration = 0.2f;

    [Header("Offsets centrados")]
    private Vector3 rightOffset = new Vector3(0f, 0f, 0f);
    private Vector3 leftOffset = new Vector3(0f, 0f, 0f);

    [Header("Color del puño")]
    [SerializeField] private SpriteRenderer attackRenderer;

    private Vector3 originalScale;
    private bool isAttacking = false;

    private void Start()
    {
        originalScale = attackGO.transform.localScale;
    }

    public void DoAttack(bool facingRight)
    {
        if (isAttacking) return;

        isAttacking = true;

        attackGO.transform.localScale = originalScale;
        attackGO.transform.localPosition = facingRight ? rightOffset : leftOffset;

        float direction = facingRight ? 1f : -1f;

        attackGO.SetActive(true);

        // Nueva escala destino en X y Y
        Vector3 targetScale = new Vector3(
            originalScale.x * attackScale * direction,
            originalScale.y * attackScale,
            originalScale.z
        );

        // Animamos en ambos ejes (X y Y)
        attackGO.transform.DOScale(targetScale, attackDuration)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                attackGO.transform.localScale = originalScale;
                attackGO.SetActive(false);
                isAttacking = false;
            });
    }
}
