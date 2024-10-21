using Unity.Mathematics;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public Rigidbody planet;
    int randomRotation;
    Quaternion rotation;
    Vector3 speed;
    public float targetTime = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Pick a random direction and rotation
        planet = this.GetComponent<Rigidbody>();
        rotation = UnityEngine.Random.rotation;
        float randomSpeedx = UnityEngine.Random.Range(-0.03f, 0.03f);
        float randomSpeedy = UnityEngine.Random.Range(-0.03f, 0.03f);
        float randomSpeedz = UnityEngine.Random.Range(-0.03f, 0.03f);

        speed = new Vector3(randomSpeedx, randomSpeedy, randomSpeedz);
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        // planet.MovePosition(transform.position + (transform.forward * randomSpeed * Time.deltaTime));
        planet.AddForce(speed);
        if(targetTime <= 0.0f){
            changeDirection();
            targetTime = 30.0f;
        }
    }
    void changeDirection(){
        rotation = UnityEngine.Random.rotation;
        // for(int i = 0; i <10; i++){
        //     FindFirstObjectByType<Spawner>().SpawnSphere();
        // }
        

    }
}
