using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSettingSO audioSetting;
    [SerializeField] private UnityEngine.Audio.AudioMixer mixer;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(audioSetting.mixerParameter, 1f);
        UpdateVolume(slider.value);
        slider.onValueChanged.AddListener(UpdateVolume);
    }
    private void Update()
    {
        slider.onValueChanged.AddListener(UpdateVolume);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(UpdateVolume);
    }

    private void UpdateVolume(float value)
    {
        audioSetting.volume = value;
        audioSetting.ApplyVolume(mixer);
    }

    public void SaveVolume()
    {
        audioSetting.SaveVolume();
    }
}
