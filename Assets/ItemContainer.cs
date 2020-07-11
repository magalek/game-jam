using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;

    private void Awake() {
        slots = GetComponentsInChildren<Slot>().ToList();
    }
}
