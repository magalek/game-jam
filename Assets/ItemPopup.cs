using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{

    private static TextMeshProUGUI textObject;
    private static Image imageObject;
    private static Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        textObject = GetComponentInChildren<TextMeshProUGUI>();
        imageObject = transform.Find("Image").GetComponentInChildren<Image>();
    }

    public static void Show(Item item) {
        animator.SetTrigger("ShowPopup");
        textObject.text = $"{item.name} acquired";
        imageObject.sprite = item.sprite;
    }
}
