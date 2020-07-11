using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechManager : MonoBehaviour
{
    public MechContainer mechContainer;
    public InventoryContainer inventoryContainer;

    private void Start() {
        GameObject character = GameObject.Find("Character");

        GameObject inventory = GameObject.Find("Inventory Panel");

        foreach (Item item in character.GetComponent<Inventory>().items) {
            inventory.GetComponentInChildren<ItemContainer>().AddItemToSlot(item);
        }
    }
}
