using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class LocaleChanger : MonoBehaviour
{
	public Variable<LocaleChanger> so;
	private string localeIDSave = "LocaleID";


	private void Awake()
	{
		if (so.Value == null)
		{
			so.Set(this);
		}
		else
		{
			Debug.Log("Locale Changer Already Exists");
		}
		SceneManager.sceneUnloaded += OnSceneChange;
	}

	private void OnSceneChange(Scene scene)
	{
		so.Set(this);
	}

	private void OnEnable()
	{
		ChangeLocale(PlayerPrefs.GetInt(localeIDSave, 0));
	}

	private void Start()
	{

	}

	public int GetCurrentID()
	{
		return LocalizationSettings.AvailableLocales.Locales.FindIndex(x => x == LocalizationSettings.SelectedLocale);
	}

	public void ChangeLocale(int id)
	{
		StartCoroutine(SetLocale(id));
		PlayerPrefs.SetInt(localeIDSave, id);
		PlayerPrefs.Save();
	}

	public void ChangeLocale()
	{
		ChangeLocale((GetCurrentID() + 1) % LocalizationSettings.AvailableLocales.Locales.Count);
	}


	IEnumerator SetLocale(int id)
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
	}
}
