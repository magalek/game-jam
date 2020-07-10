using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class Event : ScriptableObject
{
    [TextArea] public string description;

    [TextArea] public string succesMessage;
    [TextArea] public string failMessage;


    public List<ItemSlot> Items;
}
