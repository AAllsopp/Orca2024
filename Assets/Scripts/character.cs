using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class character : MonoBehaviour
{   
    private CharacterController charController;
    public float Speed=5f;
    private bool playerGround; 
    private Vector3 playerSize = new Vector3 (1,1,1);
    private float rotationSpeed = 270f;
    private Vector3 rotation;
    private Vector3 ScaleSize = new Vector3(0.1f, 0.1f, 0.1f);
    public GameObject camRot;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime, 0, Input.GetAxis("Vertical")*Time.deltaTime);
        move = this.transform.TransformDirection(move);
        charController.Move(move*Speed);

        transform.rotation = camRot.transform.rotation;
    

    }

        void OnControllerColliderHit(ControllerColliderHit hit){


        if(hit.gameObject.CompareTag("Food")){
            Vector3 foodSize = hit.collider.bounds.size;
           // Debug.Log("Player x size: " + playerSize.x);
          //  Debug.Log("Player y size: " + playerSize.y);
           // Debug.Log("Player z size: " + playerSize.z);

            if(playerSize.x >= foodSize.x){
                Vector3 newSize = vectorScale(foodSize, 0.4f);
                gameObject.transform.localScale += newSize;
                playerSize += newSize;
                
                Destroy(hit.gameObject);
                
            }
            else{
                Destroy(gameObject); // >:(
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
