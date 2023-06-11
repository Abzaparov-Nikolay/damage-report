using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
	[SerializeField] private Variable<AudioController> so;
	[SerializeField] private AudioMixer Mixer;

	private Dictionary<AudioGroup, string> GroupNames = new();

	private string masterName = "AudioMaster";
	private string musicName = "AudioBackground";
	private string effectsName = "AudioEffects";

	private void Awake()
	{
		if (so.Value == null)
		{
			so.Set(this);
			SceneManager.sceneUnloaded += OnSceneChange;
		}
		else
		{
			Debug.Log("AudioController exists");
		}
		GroupNames.Add(AudioGroup.Master, masterName);
		GroupNames.Add(AudioGroup.Background, musicName);
		GroupNames.Add(AudioGroup.Effects, effectsName);
	}

	private void OnSceneChange(Scene scene)
	{
		so.Set(this);
	}

	private void Start()
	{
		LoadAudioSettings();
	}

	private void OnDisable()
	{
		SaveAudioSettings();
	}

	public void LoadAudioSettings()
	{
		Mixer.SetFloat(masterName, Mathf.Log10(PlayerPrefs.GetFloat(masterName, 1)) * 20);
		Mixer.SetFloat(musicName, Mathf.Log10(PlayerPrefs.GetFloat(musicName, 1)) * 20);
		Mixer.SetFloat(effectsName, Mathf.Log10(PlayerPrefs.GetFloat(effectsName, 1)) * 20);
	}

	private void SaveAudioSettings()
	{
		PlayerPrefs.Save();
	}

	public void ChangeVolume(float valuePercentage, AudioGroup group)
	{
		Mixer.SetFloat(GroupNames[group], Mathf.Log10(valuePercentage) * 20);
		PlayerPrefs.SetFloat(GroupNames[group], valuePercentage);
	}

	public float GetVolume(AudioGroup group)
	{
		return PlayerPrefs.GetFloat(GroupNames[group], 1);
	}
}

public enum AudioGroup
{
	Master,
	Background,
	Effects
}
