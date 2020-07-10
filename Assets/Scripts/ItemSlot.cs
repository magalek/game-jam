using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] [TextArea] private string winMessage;
    [SerializeField] [TextArea] private string loseMessage;
}
