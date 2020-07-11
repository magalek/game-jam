using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items;

    public void AddItem(Item item) {
        items.Add(item);
    }
}
