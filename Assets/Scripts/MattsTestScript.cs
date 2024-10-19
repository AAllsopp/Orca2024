using UnityEngine;

public class MattsTestScript : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public float flapStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myRigidBody.linearVelocity = Vector3.up * flapStrength;
        }
    }
}
