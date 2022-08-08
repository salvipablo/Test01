using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    public float jumpForce;

    public bool itCanJump;
    private bool itCanMoveForward;
    private bool itCanMoveBackwards;
    private bool itCanMoveRight;
    private bool itCanMoveLeft;

    public Vector2 turnSensitivity;

    private new Transform camera;

    private Rigidbody rb;

    public GameObject objInventory;

    public bool ItCanMoveForward { get => itCanMoveForward; set => itCanMoveForward = value; }
    public bool ItCanMoveBackwards { get => itCanMoveBackwards; set => itCanMoveBackwards = value; }
    public bool ItCanMoveRight { get => itCanMoveRight; set => itCanMoveRight = value; }
    public bool ItCanMoveLeft { get => itCanMoveLeft; set => itCanMoveLeft = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        ItCanMoveForward = true;
        ItCanMoveBackwards = true;
        ItCanMoveRight = true;
        ItCanMoveLeft = true;

        Cursor.lockState = CursorLockMode.Locked;

        camera = transform.Find("Camera");
    }

    private void Update()
    {
        if (!objInventory.activeSelf) movements(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void movements(float horizontalTwistMouse, float verticalTwistMouse)
    {
        if (Input.GetButtonDown("Run"))
        {
            if (movSpeed == 5)
            {
                movSpeed *= 2;
            }
            else
            {
                movSpeed /= 2;
            }
        }

        if (ItCanMoveForward) if (Input.GetButton("WalkForward")) transform.Translate(0, 0, movSpeed * Time.deltaTime);
        if (ItCanMoveBackwards) if (Input.GetButton("WalkBackwards")) transform.Translate(0, 0, -movSpeed * Time.deltaTime);
        if (ItCanMoveRight) if (Input.GetButton("WalkRight")) transform.Translate(movSpeed * Time.deltaTime, 0, 0);
        if (ItCanMoveLeft) if (Input.GetButton("WalkLeft")) transform.Translate(-movSpeed * Time.deltaTime, 0, 0);

        if (horizontalTwistMouse != 0) transform.Rotate(Vector3.up * horizontalTwistMouse * turnSensitivity.x);
        if (verticalTwistMouse != 0)
        {
            float angle = (camera.localEulerAngles.x - verticalTwistMouse * turnSensitivity.y + 360) % 360;
            if (angle > 180) angle -= 360;
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }

        if (Input.GetButton("Jump") && itCanJump == true)
        {
            itCanJump = false;
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
