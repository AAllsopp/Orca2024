using Unity.Mathematics;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public Rigidbody planet;
    int randomRotation;
    Quaternion rotation;
    Vector3 speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Pick a random direction and rotation
        planet = this.GetComponent<Rigidbody>();
        rotation = UnityEngine.Random.rotation;
        float randomSpeedx = UnityEngine.Random.Range(-0.05f, 0.05f);
        float randomSpeedy = UnityEngine.Random.Range(-0.05f, 0.05f);
        float randomSpeedz = UnityEngine.Random.Range(-0.05f, 0.05f);

        speed = new Vector3(randomSpeedx, randomSpeedy, randomSpeedz);
    }

    // Update is called once per frame
    void Update()
    {
        // planet.MovePosition(transform.position + (transform.forward * randomSpeed * Time.deltaTime));
        planet.AddForce(speed);
    }
}
