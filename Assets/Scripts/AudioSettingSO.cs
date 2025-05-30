using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioSetting", menuName = "Audio/Setting")]
public class AudioSettingSO : ScriptableObject
{
    public string mixerParameter = "Volume";
    public float volume = 1f;
    private const float minDB = -80f;
    private const float maxDB = 0f;

    public void ApplyVolume(AudioMixer mixer)
    {
        float volumeDB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        mixer.SetFloat(mixerParameter, volumeDB);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(mixerParameter, volume);
    }

    public void LoadVolume(AudioMixer mixer)
    {
        volume = PlayerPrefs.GetFloat(mixerParameter, 1f);
        ApplyVolume(mixer);
    }
}
