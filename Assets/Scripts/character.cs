using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]

public class character : MonoBehaviour
{   
    private CharacterController charController;
    private Vector3 playerVel;
    public float Speed=5f;
    private bool playerGround; 
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerSize = new Vector3 (1,1,1);



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

    

    // ?? is this the correct ControllerColliderHit 
    void OnControllerColliderHit(ControllerColliderHit hit){

       // Rigidbody food = hit.collider.attachedRigidBody;
       // if(food == null){
         //   return;
       // }
        // get an attribute for size of collision 
        //Vector3 size = FindFirstObjectByType<planetFood>().giveSize();
      

        if(hit.gameObject.CompareTag("Food")){
            Vector3 foodSize = hit.collider.bounds.size;
            if(playerSize.x >= foodSize.x){
                
                playerSize.x += foodSize.x;
                playerSize.y += foodSize.y;
                playerSize.z += foodSize.z;
                Destroy(hit.gameObject);
                
            }

        }
       

        //float jumpOverlap;
       // if (playerSize >= 2) {
            // If player is not small, they can jump on the mushroom
            //jumpOverlap = Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground", "ShroomBounce")).Length;
       // } else {
         //   // If the player is small, they cannot jump on the mushroom
         //   jumpOverlap = Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length;
        //}
        
    }
}
