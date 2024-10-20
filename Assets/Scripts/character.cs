using UnityEngine;
// using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class character : MonoBehaviour
{   
    private CharacterController charController;
    public float Speed=5f;
    private bool playerGround; 
    private Vector3 playerSize = new Vector3 (1,1,1);
    // private float rotationSpeed = 270f;
    private Vector3 rotation;
    private Vector3 ScaleSize = new Vector3(0.1f, 0.1f, 0.1f);
    public GameObject cam_ref;
    // public CinemachineCamera cinemachineCamera;
    public CinemachineOrbitalFollow cinemachineCamera;



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
        if(Input.GetKey(KeyCode.Space)){
            move.y += Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftShift)){
            move.y -= Time.deltaTime;
        }
        charController.Move(move*Speed*playerSize.x);

        transform.rotation = cam_ref.transform.rotation;
        
    

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
                UpdateCameraOrbit(newSize.x*5);
                Debug.Log("Player Size: " + playerSize.x);
                
            }
            else{
                Destroy(gameObject); // >:(
            }

        }
        
    }

    void UpdateCameraOrbit(float size)
    {
        if (cinemachineCamera != null)
        {
            
                // You can adjust these scaling factors to control how the height and radius change
                float heightAdder = size; // Increase height based on size
                float radiusAdder = size; // Increase radius based on size

                cinemachineCamera.Orbits.Top.Height += heightAdder;
                //cinemachineCamera.Orbits.Center.Height += heightAdder;
                cinemachineCamera.Orbits.Bottom.Height -= heightAdder;

                cinemachineCamera.Orbits.Top.Radius += radiusAdder;
                cinemachineCamera.Orbits.Center.Radius += radiusAdder;
                cinemachineCamera.Orbits.Bottom.Radius += radiusAdder;
        }
    }

    public Vector3 getPos() {
        return charController.transform.position;
    }

    public Vector3 getSize() {
        return playerSize;
    }

    Vector3 vectorScale(Vector3 curSize, float multiplier){
        curSize.x *= multiplier;
        curSize.y *= multiplier;
        curSize.z *= multiplier;

        return curSize;

    }
}
