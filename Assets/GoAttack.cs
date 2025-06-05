using UnityEngine;

public class GoAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Color attackColor;

    public void SetColorAttack(Color color)
    {
        attackColor = color;
    }
}
