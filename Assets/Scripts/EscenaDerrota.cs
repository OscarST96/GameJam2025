using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaDerrota : MonoBehaviour
{
    [SerializeField] private int indexSong;
    private void Start()
    {
        PlaySong();
    }
    public void Escenas(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void PlaySong()
    {
        AudioManager.instance.PlayMusic(indexSong);
    }
    public void PlaySFX()
    {
        AudioManager.instance.PlaySFX(0);
    }
}
