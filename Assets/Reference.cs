using UnityEngine;

public class Reference : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.position = player.transform.position;
    }
}
