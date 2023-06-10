using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button button;
    [SerializeField] private Variable<Inventory> inventory;

    private Item item;
    private UnityAction addItemAction;

    public event Action OnItemSelected;

    public void SetContent(Item item)
    {
        this.item = item;
        image.sprite = item.Image;
        title.text = item.Title.GetLocalizedString();
        description.text = item.Description.GetLocalizedString();
        button.onClick.AddListener(addItemAction);
    }

    private void Awake()
    {
        addItemAction = new UnityAction(AddItem);
    }

    private void AddItem()
    {
        inventory.Value.AddItem(item);
        OnItemSelected?.Invoke();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(addItemAction);
    }
}
