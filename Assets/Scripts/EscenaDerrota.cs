using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaDerrota : MonoBehaviour
{
    public void Escenas(string scene)
    {
        SceneManager.LoadScene(scene);  
    }
}
