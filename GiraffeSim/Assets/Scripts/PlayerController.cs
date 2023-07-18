using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character Attributes:")]
    public float MOVEMENT_BASE_SPEED = 5.0f;

    [Space]
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;

    void Update() {
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = movementDirection.sqrMagnitude;
        movementDirection.Normalize();
    }

    void Move() {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate() {
        if (movementDirection != Vector2.zero) {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
            animator.SetFloat("Speed", movementSpeed);
        }
    }
}