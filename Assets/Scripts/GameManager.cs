using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelOpciones;

    private void Start()
    {
        panelOpciones.SetActive(false);
    }
    public void Opciones()
    {
        panelOpciones.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Volver()
    {
        panelOpciones.SetActive(false);
        Time.timeScale = 1f;
    }
}
