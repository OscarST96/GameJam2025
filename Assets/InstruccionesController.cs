using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstruccionesController : MonoBehaviour
{
    public GameObject imagen1; // Referencia a la primera imagen de instrucciones
    public GameObject imagen2; // Referencia a la segunda imagen de instrucciones
    public Button botonSiguiente; // Bot�n para pasar a la siguiente imagen
    public Button botonComenzar; // Bot�n para comenzar el juego

    private void Start()
    {
        // Asegurarse de que la segunda imagen est� oculta al principio
        imagen2.SetActive(false);

        // Agregar listeners a los botones
        botonSiguiente.onClick.AddListener(MostrarSegundaImagen);
        botonComenzar.onClick.AddListener(ComenzarJuego);
    }

    // Funci�n para mostrar la segunda imagen
    private void MostrarSegundaImagen()
    {
        imagen1.SetActive(false); // Ocultar la primera imagen
        imagen2.SetActive(true);  // Mostrar la segunda imagen
        botonSiguiente.gameObject.SetActive(false); // Ocultar el bot�n de siguiente
        botonComenzar.gameObject.SetActive(true);  // Mostrar el bot�n para comenzar el juego
    }

    private void ComenzarJuego()
    {
        SceneManager.LoadScene("GameUno");
    }
}
