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

	//public LocalizedString EnglishText;
	//public LocalizedString RussianText;

	public void onValueChanged(int id)
	{
		Changer.Value.ChangeLocale(id);
	}

	private void OnEnable()
	{
		//LocalizationSettings.SelectedLocaleChanged += OnLanguageChange;
		//LanguageDropdown.ClearOptions();
		//LanguageDropdown.AddOptions(new List<TMP_Dropdown.OptionData>()
		//{
		//	new TMP_Dropdown.OptionData("English"),
		//	new TMP_Dropdown.OptionData("Русский")
		//}) ;
		LanguageDropdown.value = Changer.Value.GetCurrentID();
		LanguageDropdown.RefreshShownValue();
	}

	//private void OnDisable()
	//{
	//	LocalizationSettings.SelectedLocaleChanged -= OnLanguageChange;
	//}

	//private void OnLanguageChange(Locale locale)
	//{
	//	LanguageDropdown.ClearOptions();
	//	LanguageDropdown.AddOptions(new List<TMP_Dropdown.OptionData>()
	//	{
	//		new TMP_Dropdown.OptionData(EnglishText.GetLocalizedString()),
	//		new TMP_Dropdown.OptionData(RussianText.GetLocalizedString())
	//	});
	//	LanguageDropdown.SetValueWithoutNotify(LocalizationSettings.AvailableLocales.Locales.FindIndex(l => l == locale));
	//	LanguageDropdown.RefreshShownValue();
	//}
}
