using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static AudioController;
using static UnityEngine.Rendering.DebugUI;

public class AudioChanger : MonoBehaviour
{
	[SerializeField] private Variable<AudioController> controller;

	[SerializeField] private Slider masterSlider;
	[SerializeField] private Slider effectsSlider;
	[SerializeField] private Slider musicSlider;


	private void Start()
	{

	}

	private void OnEnable()
	{
		LoadAudioValues();
		musicSlider.onValueChanged.AddListener(onMusicSliderChange);
		masterSlider.onValueChanged.AddListener(onAudioSliderChange);
		effectsSlider.onValueChanged.AddListener(onSFXSliderChange);
	}

	private void OnDisable()
	{
		musicSlider.onValueChanged.RemoveListener(onMusicSliderChange);
		masterSlider.onValueChanged.RemoveListener(onAudioSliderChange);
		effectsSlider.onValueChanged.RemoveListener(onSFXSliderChange);
	}

	private void LoadAudioValues()
	{
		masterSlider.value = GetAudioGroupVolumePercentage(AudioGroup.Master);
		musicSlider.value = GetAudioGroupVolumePercentage(AudioGroup.Background);
		effectsSlider.value = GetAudioGroupVolumePercentage(AudioGroup.Effects);
	}

	private float GetAudioGroupVolumePercentage(AudioGroup group)
	{
		return controller.Value.GetVolume(group);
	}

	private void onAudioSliderChange(float value)
	{
		controller.Value.ChangeVolume(value, AudioGroup.Master);
	}

	private void onSFXSliderChange(float value)
	{
		controller.Value.ChangeVolume(value, AudioGroup.Effects);
	}

	private void onMusicSliderChange(float value)
	{
		controller.Value.ChangeVolume(value, AudioGroup.Background);
	}
}
