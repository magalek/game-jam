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

        ResultScreenManager.Instance.resultImage.sprite = currentEvent.eventImage;

        List<Slot> usedSlots = mechContainer.slots.Where(i => i.item != null).ToList();

        Item properItem = null;

        if (usedSlots.Count > 0) {
            bool success = false;

            foreach (var slot in usedSlots) {
                success = currentEvent.Items.Any(i => i.item == slot.item);

                if (success) {
                    properItem = slot.item;
                    break;
                }
            }

            if (success) {
                ItemSlot itemWhichSucceded = currentEvent.Items.FirstOrDefault(i => i.item == properItem);
                textObject.text = string.Format(currentEvent.succesMessage, itemWhichSucceded.option == Option.First ? itemWhichSucceded.item.firstSuccesMessage : itemWhichSucceded.item.secondSuccesMessage);
                GameManager.Instance.Points++;
            }
            else {
                textObject.text = string.Format(currentEvent.failMessage, usedSlots[Random.Range(0, usedSlots.Count)].item.failMessage);
                GameManager.Instance.Points--;
            }
        }
        else {
            textObject.text = string.Format(currentEvent.failMessage, "Your cyborg did nothing");
            GameManager.Instance.Points--;
        }
    }
}
