using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;

    public MechManager manager;

    private void Awake() {
        manager = GetComponentInParent<MechManager>();
        slots = GetComponentsInChildren<Slot>().ToList();

        foreach (var slot in slots) {
            slot.container = this;
        }
    }

    public void AddItemToSlot(Item item) {
        Slot slot = slots.FirstOrDefault(s => s.empty);

        if (slot != null) {
            slot.AddItem(item);
        }
    }
}
