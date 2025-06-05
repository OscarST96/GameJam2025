using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Mixer Settings")]
    [SerializeField] private AudioSettingSO masterVolumeSO;
    [SerializeField] private AudioSettingSO sfxVolumeSO;

    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Clips")]
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] sfxClips;


    public void UpdateVolume(AudioSettingSO setting, float value)
    {
        setting.volume = value;
        setting.ApplyVolume(audioMixer);
        setting.SaveVolume();
    }

    public float GetVolume(AudioSettingSO setting) => setting.volume;

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("�ndice de m�sica inv�lido");
        }
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxClips.Length)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
        else
        {
            Debug.LogWarning("�ndice de SFX inv�lido");
        }
    }
}
