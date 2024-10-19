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
    private Vector3 playerSize = new Vector3 (1,1,1);
    private float rotationSpeed = 270f;
    private Vector3 rotation;
    private Vector3 ScaleSize = new Vector3(0.1f, 0.1f, 0.1f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxis("Horizontal")*rotationSpeed*Time.deltaTime, 0);
        Vector3 move = new Vector3(0,0, Input.GetAxis("Vertical")*Time.deltaTime);
        move = this.transform.TransformDirection(move);
        charController.Move(move*Speed);
        this.transform.Rotate(this.rotation);

    }

        void OnControllerColliderHit(ControllerColliderHit hit){


        if(hit.gameObject.CompareTag("Food")){
            Vector3 foodSize = hit.collider.bounds.size;
            if(playerSize.x >= foodSize.x){
                
                Vector3 newSize = vectorScale(foodSize, 0.1f);
                gameObject.transform.localScale += newSize;
                
               // playerSize.x += foodSize.x;
               // playerSize.y += foodSize.y;
               // playerSize.z += foodSize.z;
                Destroy(hit.gameObject);
                
            }

        }
        
    }
    Vector3 vectorScale(Vector3 curSize, float multiplier){
        curSize.x *= multiplier;
        curSize.y *= multiplier;
        curSize.z *= multiplier;

        return curSize;

    }
}
