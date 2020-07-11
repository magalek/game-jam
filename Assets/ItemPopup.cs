using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPopup : MonoBehaviour
{
    private static Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public static void Show() {
        animator.SetTrigger("ShowPopup");
    }
}
