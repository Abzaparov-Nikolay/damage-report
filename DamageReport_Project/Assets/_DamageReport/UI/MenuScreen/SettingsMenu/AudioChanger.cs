using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AudioChanger : MonoBehaviour
{
	[SerializeField] private AudioMixer Mixer;

	[SerializeField] private Slider masterSlider;
	[SerializeField] private Slider effectsSlider;
	[SerializeField] private Slider musicSlider;

	private string masterSave = "AudioMaster";
	private string musicSave = "AudioBackground";
	private string effectsSave = "AudioEffects";


	private void Start()
	{
		
	}

	private void OnEnable()
	{
		musicSlider.onValueChanged.AddListener(onMusicSliderChange);
		masterSlider.onValueChanged.AddListener(onAudioSliderChange);
		effectsSlider.onValueChanged.AddListener(onSFXSliderChange);
		LoadAudioValues();
	}

	private void OnDisable()
	{
		musicSlider.onValueChanged.RemoveListener(onMusicSliderChange);
		masterSlider.onValueChanged.RemoveListener(onAudioSliderChange);
		effectsSlider.onValueChanged.RemoveListener(onSFXSliderChange);
		SaveAudioSettings();
	}

	public void LoadAudioSettings()
	{
		Mixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat(masterSave, 1)) * 20);
		Mixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat(effectsSave, 1)) * 20);
		Mixer.SetFloat("BackgroundVolume", Mathf.Log10(PlayerPrefs.GetFloat(musicSave, 1)) * 20);
	}

	private void LoadAudioValues()
	{
		masterSlider.value = PlayerPrefs.GetFloat(masterSave, 1);
		musicSlider.value = PlayerPrefs.GetFloat(musicSave, 1);
		effectsSlider.value = PlayerPrefs.GetFloat(effectsSave, 1);
	}

	private void SaveAudioSettings()
	{
		PlayerPrefs.SetFloat(masterSave, musicSlider.value);
		PlayerPrefs.SetFloat(musicSave, effectsSlider.value);
		PlayerPrefs.SetFloat(effectsSave, masterSlider.value);
		PlayerPrefs.Save();
	}

	private void onAudioSliderChange(float value)
	{
		Mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
		PlayerPrefs.SetFloat(masterSave, value);
	}

	private void onSFXSliderChange(float value)
	{
		Mixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
		PlayerPrefs.SetFloat(effectsSave, value);

	}

	private void onMusicSliderChange(float value)
	{
		Mixer.SetFloat("BackgroundVolume", Mathf.Log10(value) * 20);
		PlayerPrefs.SetFloat(musicSave, value);

	}

}
