using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    public float jumpForce;

    public bool itCanJump;
    public bool itCanMoveForward;
    public bool itCanMoveBackwards;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        itCanMoveForward = true;
        itCanMoveBackwards = true;
    }

    private void Update()
    {
        movements();
    }

    private void movements()
    {
        if (itCanMoveForward) if (Input.GetButton("WalkForward")) transform.Translate(0, 0, movSpeed * Time.deltaTime);
        if (itCanMoveBackwards) if (Input.GetButton("WalkBackwards")) transform.Translate(0, 0, -movSpeed * Time.deltaTime);

        if (Input.GetButton("WalkLeft")) transform.Translate(-movSpeed * Time.deltaTime, 0, 0);
        if (Input.GetButton("WalkRight")) transform.Translate(movSpeed * Time.deltaTime, 0, 0);
        
        if (Input.GetButton("Jump") && itCanJump == true)
        {
            itCanJump = false;
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
