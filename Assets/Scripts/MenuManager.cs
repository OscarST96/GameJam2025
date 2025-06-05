using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCreditos;
    private void Start()
    {
        AudioManager.instance.PlayMusic(0);
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Esc()
    {
        Application.Quit();
    }
    public void Opciones()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
        panelCreditos.SetActive(false);
    }
    public void Creditos()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);
    }
    public void Volver()
    {
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(false);
    }  
}
