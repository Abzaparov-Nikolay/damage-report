using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
	public TMP_Dropdown LanguageDropdown;
	public Variable<LocaleChanger> Changer;

	public void onValueChanged(int id)
	{
		Changer.Value.ChangeLocale(id);
	}

	public void ChangeLocale()
	{
		Changer.Value.ChangeLocale();
	}

	private void OnEnable()
	{
		LanguageDropdown.value = Changer.Value.GetCurrentID();
		LanguageDropdown.RefreshShownValue();
	}
}
