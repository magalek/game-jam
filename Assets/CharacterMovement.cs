using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [Header("Customizable Fields")]
    [SerializeField] [Range(10, 100)] private float speed = 10;

    public bool CanMove { get; set; }

    private bool isMoving;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (CanMove) Move();
    }

    private void Move() {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0) {
            GetComponent<SpriteRenderer>().flipX = xAxis > 0 ? true : false;
        }


        if (xAxis != 0 || yAxis != 0) {
            animator.SetBool("IsMoving", true);

            Vector3 moveVector = new Vector3(xAxis, yAxis, 0);

            moveVector.Normalize();

            transform.Translate(moveVector * (Time.deltaTime * speed));
        }
        else animator.SetBool("IsMoving", false);
    }
}
