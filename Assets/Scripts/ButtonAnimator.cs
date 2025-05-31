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

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Highlight", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Highlight", false);
    }
}