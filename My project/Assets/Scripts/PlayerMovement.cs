using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 50f;
    public float jumpPower = 60f;
    public float gravity = 115f;
    public float lookSpeed = 13f;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    private Animator animator;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (characterController.isGrounded)
        {
            moveDirection.y = -0.5f;

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpPower;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Aktualizacja animatora
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput > 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isWalkBack", false);
        }
        else if (verticalInput < 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkBack", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkBack", false);
        }

        if (horizontalInput < 0)
        {
            animator.SetBool("isWalkLeft", true);
            animator.SetBool("isWalkRight", false);
        }
        else if (horizontalInput > 0)
        {
            animator.SetBool("isWalkLeft", false);
            animator.SetBool("isWalkRight", true);
        }
        else
        {
            animator.SetBool("isWalkLeft", false);
            animator.SetBool("isWalkRight", false);
        }
    }
}