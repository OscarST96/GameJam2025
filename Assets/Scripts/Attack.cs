using DG.Tweening;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Player player;

    [Header("Ataque")]
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private float moveDistance;
    [SerializeField] private float attackDuration = 0.2f;

    [Header("Offsets centrados")]
    private Vector3 startOffset = new Vector3(0f, 0f, 0f);

    public void DoAttack(bool facingRight)
    {
        float direction = facingRight ? 1f : -1f;

        Vector3 initialPos = transform.position + new Vector3(startOffset.x * direction, startOffset.y, startOffset.z);

        GameObject instance = Instantiate(attackPrefab, initialPos, Quaternion.identity, transform);

        instance.transform.localScale = Vector3.one * 0.1f;

        if (!facingRight)
        {
            Vector3 flipped = instance.transform.localScale;
            flipped.x *= -1;
            instance.transform.localScale = flipped;
        }

        Vector3 targetPos = instance.transform.localPosition + new Vector3(moveDistance * direction, 0f, 0f);
        Vector3 punchScale = Vector3.one * 0.8f;
        Vector3 finalScale = Vector3.one * 0.2f;

        // Animaciones
        instance.transform.DOScale(punchScale, 0.1f).SetEase(Ease.InQuint);
        instance.transform.DOLocalMove(targetPos, attackDuration)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                instance.transform.DOScale(finalScale, 0.3f)
                    .SetEase(Ease.InQuad)
                    .OnComplete(() =>
                    {
                        Destroy(instance);
                    });
            });
    }
}

