using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetFood : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void eatFood(){
        Destroy(gameObject);
    }
    public Vector3 giveSize(){
        return GetComponent<Collider>().bounds.size;
    }
        
}
