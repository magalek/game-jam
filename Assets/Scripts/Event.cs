﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class Event : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private List<ItemSlot> items;
}
