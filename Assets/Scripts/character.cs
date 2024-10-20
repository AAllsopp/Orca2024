using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class character : MonoBehaviour
{   
    private CharacterController charController;
    private Vector3 playerVel;
    public float Speed=5f;
    private bool playerGround; 
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerGround = charController.isGrounded;

        if (playerGround && playerVel.y <0){
            playerVel.y = 0f;

        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charController.Move(move*Time.deltaTime* Speed);

        if(move != Vector3.zero){
            gameObject.transform.forward = move;
        }

        if(Input.GetButtonDown("Jump") && playerGround){
            playerVel.y += Mathf.Sqrt(jumpHeight * -3.0f *gravityValue);
        }
        playerVel.y += gravityValue*Time.deltaTime;
        charController.Move(playerVel*Time.deltaTime);
    }
}
