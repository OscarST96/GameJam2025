using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject attackGO;
    [SerializeField] private float attackScale = 1.5f;
    [SerializeField] private float attackDuration = 0.3f;

    private Vector3 rightOffset = new Vector3(1, 0, 0);
    private Vector3 leftOffset = new Vector3(-1, 0, 0);

    public void DoAttack(bool facingRight)
    {
        if (attackGO == null) return;

        // Posicionar el ataque hacia la dirección correcta
        attackGO.transform.localPosition = facingRight ? rightOffset : leftOffset;
        attackGO.transform.localScale = Vector3.one;

        attackGO.SetActive(true);

        // Animación con DOTween
        attackGO.transform.DOScaleX(attackScale, attackDuration)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                attackGO.transform.localScale = Vector3.one;
                attackGO.SetActive(false);
            });
    }
}
