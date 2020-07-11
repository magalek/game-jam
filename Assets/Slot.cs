using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public bool empty = true;
    
    public ItemContainer container;

    private Image image;

    private void Awake() {
        image = transform.Find("Sprite").GetComponent<Image>();
    }

    public void AddItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.sprite;
        image.color = new Color(1, 1, 1, 1);
        empty = false;
    }

    public void RemoveItem() {
        item = null;
        image.sprite = null;
        image.color = new Color(1, 1, 1, 0);
        empty = true;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (item == null) return;

        if (eventData.button == PointerEventData.InputButton.Left) {
            if (container is InventoryContainer) {
                container.manager.mechContainer.AddItemToSlot(item);
                RemoveItem();
            }
            if (container is MechContainer) {
                container.manager.inventoryContainer.AddItemToSlot(item);
                RemoveItem();
            }
        }
    }
}
