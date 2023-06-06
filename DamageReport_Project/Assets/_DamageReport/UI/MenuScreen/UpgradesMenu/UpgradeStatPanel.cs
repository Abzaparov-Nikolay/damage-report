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
        CurrentBonus.text = "big retard";
    }
}
