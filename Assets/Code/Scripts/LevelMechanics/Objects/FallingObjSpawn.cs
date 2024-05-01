using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FallingObjSpawn : MonoBehaviour
{  
    public Transform origen;
    public GameObject objectToSpawn;
    public float waitTime;
    public float spawnInterval;
    


    private void Update()
    {
        waitTime += Time.deltaTime;

       
        if (waitTime >= spawnInterval)
        {
          
            waitTime = 0f;
            Instantiate(objectToSpawn, origen.position, Quaternion.identity);
       
        }
    }

    
}
