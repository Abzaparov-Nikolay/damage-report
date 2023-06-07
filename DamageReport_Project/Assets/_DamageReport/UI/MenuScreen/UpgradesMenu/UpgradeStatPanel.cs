using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StatBonusName;
    [SerializeField] private TextMeshProUGUI CurrentBonus;
    [SerializeField] private Button SubmitButton;
    [SerializeField] private TextMeshProUGUI UpgradeCost;

    public void OnSubmitUpgradeButtonClick()
    {

    }

    public void SetFromUpgrade(Upgrade upgrade)
    {
        StatBonusName.text = upgrade.Name;
        SetCurrentBonus(upgrade.bonus);
        UpgradeCost.text = "0";
    }

    private void SetCurrentBonus(StatBonus bonus)
    {
        if(bonus is FlatStatBonus)
        {
            CurrentBonus.text = $"+{(bonus as FlatStatBonus).amount.Value}";
        }
        else if(bonus is PercentageStatBonus)
        {
            CurrentBonus.text = $"+{(bonus as PercentageStatBonus).percentage.Value}%";
		}
        else
        {
			CurrentBonus.text = "big retard";
		}
	}
}
