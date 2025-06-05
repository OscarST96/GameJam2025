using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private int levelIndex;

    private void Start()
    {
        AudioManager.instance.PlayMusic(levelIndex);
        panelOpciones.SetActive(false);
    }
    public void Opciones()
    {
        AudioManager.instance.PlaySFX(0);
        panelOpciones.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Volver()
    {
        panelOpciones.SetActive(false);
        Time.timeScale = 1f;
    }
}
