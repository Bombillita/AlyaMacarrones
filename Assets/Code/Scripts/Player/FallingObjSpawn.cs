using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class FallingObjSpawn : MonoBehaviour
{
    public float n;
    public Transform origen;
    public GameObject objetoSpawneable;
   // public float force;
    public float waitTime;
    private float timeSinceLast;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeSinceLast < waitTime)
        {
            SpawnFallingObj();
            timeSinceLast = Time.time;

        }
    }
   
    private void SpawnFallingObj()
    {
        GameObject FallingObj = Instantiate(objetoSpawneable, origen.position, Quaternion.identity);
       // FallingObj.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
        Destroy(FallingObj, n);

    }
}
