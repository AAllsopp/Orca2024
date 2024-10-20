using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject mySphere1;
    public GameObject mySphere2;
    public GameObject mySphere3;
    public GameObject mySphere4;
    public GameObject mySphere5;
    public GameObject mySphere6;
    public GameObject mySphere7;
    public GameObject mySphere8;
    public GameObject mySphere9;
    public GameObject mySphere10;
    public GameObject mySphere11;
    public GameObject mySphere12;
    public GameObject mySphere13;
    public GameObject mySphere14;
    public GameObject mySphere15;
    public GameObject mySphere16;
    public GameObject mySphere17;
    public GameObject mySphere18;
    public GameObject mySphere19;
    public GameObject mySphere20;

    private GameObject [] spheres;
    private int [] morePlanetRange = {0, 3};
    private float curSizeIndex = 6f;

    public void initializeSpawn(){
        GameObject sphereToSpawn;
        
        Vector3 playerPos = FindFirstObjectByType<character>().getPos();
        Vector3 playerSize = FindFirstObjectByType<character>().getSize();

        spheres = new GameObject[] {mySphere1, mySphere2, mySphere3};

        int listRand = Random.Range(0, spheres.Length);
        sphereToSpawn = spheres[listRand];
        Vector3 spawnPosition = setSpawn(playerSize, playerPos, sphereToSpawn, true);


        Instantiate(sphereToSpawn, spawnPosition, Quaternion.identity);
        Instantiate(mySphere1, spawnPosition, Quaternion.identity);
        

    }
    public void SpawnSphere() {
        Vector3 playerPos = FindFirstObjectByType<character>().getPos();
        Vector3 playerSize = FindFirstObjectByType<character>().getSize();
        

        spheres = new GameObject[] {mySphere1, mySphere2, mySphere3, mySphere4, mySphere5, mySphere6, mySphere7, mySphere8, mySphere9, mySphere10, mySphere11, mySphere12, mySphere13, mySphere14, mySphere15, mySphere16, mySphere17, mySphere18, mySphere19, mySphere20,};

        // changes range for more planet spawns if it moves outside the current range
        if(playerSize.x > curSizeIndex && curSizeIndex < 344f){
            morePlanetRange[0] +=1;
            morePlanetRange[1] +=1;
            curSizeIndex = spheres[morePlanetRange[1]].transform.localScale.x; 
        }
        

        //update spawn position for size of planet 


        // Logic to increase the chances based on player size
        // spawn from size of player 2below and 2 above 
        GameObject sphereToSpawn;
        
        int rand = Random.Range(0, 100); // Generate a random number from 0 to 99

        // pick the top list 
            // get the excluded less popular list 
        if (rand < 85) 
        {   
            int listRand = Random.Range(morePlanetRange[0], morePlanetRange[1]);
            sphereToSpawn = spheres[listRand]; // 60% chance for small sphere
        }
        else{
            int listRand = Random.Range(0, spheres.Length);
            sphereToSpawn = spheres[listRand];
        }
            // If player's size is exactly 2, use default even distribution
        
        
        //spawnPosition
        Vector3 spawnPosition = setSpawn(playerSize, playerPos, sphereToSpawn, false);
        Instantiate(sphereToSpawn, spawnPosition, Quaternion.identity);
        
        
    }
    public Vector3 setSpawn(Vector3 playerSize, Vector3 playerPos, GameObject planet, bool isInit){
        Vector3 spawnPoint = playerPos;
        int randScaleX;
        int randScaleY;
        int randScaleZ;
        if (isInit){
            randScaleX = Random.Range(-150, 150);
            randScaleY = Random.Range(-150, 150);
            randScaleZ = Random.Range(-150, 150);

        }else{
            randScaleX = Random.Range(-360, 360);
            randScaleY = Random.Range(-360, 360);
            randScaleZ = Random.Range(-360, 360);
        }
       
        
        spawnPoint.x += playerSize.x*randScaleX;
        spawnPoint.y += playerSize.y*randScaleY;
        spawnPoint.z += playerSize.z*randScaleZ;

        
        float planetRad = planet.transform.localScale.x/2 + 6;
        float playerRad = playerSize.x;
        if(playerRad >= spawnPoint.x - planetRad && playerRad <= spawnPoint.x + planetRad){

            if(playerRad >= spawnPoint.y - planetRad && playerRad <= spawnPoint.y + planetRad){

                if(playerRad >= spawnPoint.z - planetRad && playerRad <= spawnPoint.z + planetRad){

                    //player is colliding with current planet spawn
                    spawnPoint = setSpawn(playerSize, playerPos, planet, false);

                }
            }
        }
        


        return spawnPoint;

    }
}
