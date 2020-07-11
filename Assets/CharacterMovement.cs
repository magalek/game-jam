using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Customizable Fields")]
    [SerializeField] [Range(10, 100)] private float speed = 10;

    private void Update() {
        Move();
    }

    private void Move() {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0 || yAxis != 0) {
            GetComponent<SpriteRenderer>().flipX = xAxis > 0 ? false : true;

            Vector3 moveVector = new Vector3(xAxis, yAxis, 0);

            moveVector.Normalize();

            transform.Translate(moveVector * (Time.deltaTime * speed));
        }
    }
}
