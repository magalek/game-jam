using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class Event : ScriptableObject
{
    [TextArea] public string description;
    [Space]
    [TextArea] public string succesMessage;
    [TextArea] public string failMessage;

    public Sprite eventImage;

    public List<ItemSlot> Items;
}
