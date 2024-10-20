using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float maxRotation;
    private Rigidbody rb;
    public float jumpForce = 7f;
    public Transform jumpCheckPos;
    private bool isJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newVelocity = transform.forward * vertical * maxSpeed;
        // newVelocity.y = rb.linearVelocity.y;
        // rb.linearVelocity = newVelocity;
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;
        
        bool onGround = Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length > 0;
        if (isJump && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = false;
        }

        transform.Rotate(Vector3.up, horizontal * maxRotation * Time.fixedDeltaTime, 0f);
    }
}
