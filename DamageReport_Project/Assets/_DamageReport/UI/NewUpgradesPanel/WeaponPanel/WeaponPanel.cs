using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class WeaponPanel : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private TextMeshProUGUI additionalDescription;
    [SerializeField] private Button button;
    [SerializeField] private Variable<Inventory> inventory;

    private Weapon weapon;
    private UnityAction addWeaponAction;

    public event Action OnSelected;

    public void SetContent(Weapon weapon)
    {
        this.weapon = weapon;
        image.sprite = weapon.Image;
        title.text = weapon.Title;
        info.text = weapon.Info;
        additionalDescription.text = weapon.AdditionalDescription;
        button.onClick.AddListener(addWeaponAction);
    }

    private void Awake()
    {
        addWeaponAction = new UnityAction(AddWeapon);
    }

    private void AddWeapon()
    {
        inventory.Value.AddWeapon(weapon);
        OnSelected?.Invoke();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(addWeaponAction);
    }
}
