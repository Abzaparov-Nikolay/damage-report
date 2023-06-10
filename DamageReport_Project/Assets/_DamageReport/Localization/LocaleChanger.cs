using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

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


	IEnumerator SetLocale(int id)
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
	}
}
