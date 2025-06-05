using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Highlight", false);
    }

    private void Start()
    {
        float randomDistance = Random.Range(0.1f, 0.3f);
        float randomDuration = Random.Range(0.7f, 1f);

        transform.DOMoveY(transform.position.y + randomDistance, randomDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Highlight", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Highlight", false);
    }
}