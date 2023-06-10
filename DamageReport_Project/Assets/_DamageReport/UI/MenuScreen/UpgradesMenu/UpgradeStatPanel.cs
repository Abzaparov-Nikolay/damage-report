using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class UpgradeStatPanel : MonoBehaviour
{
    private Upgrade upgrade;
    [SerializeField] private TextMeshProUGUI StatBonusNameText;
	//private LocalizedString StatBonusName;
    [SerializeField] private TextMeshProUGUI CurrentBonus;
    [SerializeField] private Button SubmitButton;
    [SerializeField] private TextMeshProUGUI UpgradeCost;

    public static Action<object, UpgradeChangeData> UpgradeChanged;

    public void OnSubmitUpgradeButtonClick()
    {
        if (true) //can upgrade
        {
            NotifyChanges();
            DisplayValues();
        }
    }

    public void SetFromUpgrade(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        DisplayValues();
    }

	private void Start()
	{
		upgrade.Name.StringChanged += val => StatBonusNameText.text = val;
	}

	public void DisplayValues()
    {
		StatBonusNameText.text = upgrade.Name.GetLocalizedString();
		//StatBonusName = upgrade.Name;
		SetCurrentBonus(upgrade.bonus);
		UpgradeCost.text = upgrade.Cost.ToString();
	}

    private void SetCurrentBonus(StatBonus bonus)
    {
        if(bonus is FlatStatBonus)
        {
            CurrentBonus.text = $"+{bonus.ToString()}";
        }
        else if(bonus is PercentageStatBonus)
        {
            CurrentBonus.text = $"+{bonus.ToString()}%";
		}
        else
        {
			CurrentBonus.text = "big retard";
		}
	}

    private void NotifyChanges()
    {
        var data = new UpgradeChangeData(upgrade.UID, 1, upgrade.Cost);
        UpgradeChanged?.Invoke(this, data);
    }
}
