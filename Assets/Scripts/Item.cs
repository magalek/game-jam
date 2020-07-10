using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    private ItemSlot parent;

    [TextArea] public string firstSuccesMessage;
    [TextArea] public string secondSuccesMessage;
    [TextArea] public string failMessage;

    public void SetParent(ItemSlot slot) {
        parent = slot;
    }
}
