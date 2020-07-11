using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MechManager : MonoBehaviour
{
    public MechContainer mechContainer;
    public InventoryContainer inventoryContainer;

    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private Animator canvasAnimator;

    private void Start() {
        GameObject character = GameObject.Find("Character");
        GameObject inventory = GameObject.Find("Inventory Panel");

        foreach (Item item in character.GetComponent<Inventory>().items) {
            inventory.GetComponentInChildren<InventoryContainer>().AddItemToSlot(item);
        }

        Destroy(character);
    }

    public void SwipeScreen() {
        canvasAnimator.SetTrigger("Swipe");
        Event currentEvent = GameManager.Instance.currentEvent;

        List<Slot> availableItems = mechContainer.slots.Where(i => i.item != null).ToList();

        textObject.text = string.Format(currentEvent.failMessage, availableItems[Random.Range(0, availableItems.Count)].item.failMessage);
    }
}
