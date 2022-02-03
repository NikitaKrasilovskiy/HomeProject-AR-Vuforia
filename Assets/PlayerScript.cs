using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float walkSpeed = 7.5f;
    float runSpeed = 12.0f;
    float jumpSpeed = 8.0f;
    float gravitu = 20.0f;
    public Camera myCamera;
    float lookSpeed = 2.0f;
    float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDir = Vector3.zero;
    float rotationX = 0.0f;

    public bool camMove = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = camMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = camMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirrectionY = moveDir.y;
        moveDir = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && camMove && characterController.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }
        else
        {
            moveDir.y = movementDirrectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDir.y -= gravitu * Time.deltaTime;
        }

        characterController.Move(moveDir * Time.deltaTime);

        if (camMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            myCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}