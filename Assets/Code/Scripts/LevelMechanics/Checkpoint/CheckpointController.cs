using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    private Checkpoint[] _checkpoints;

    //ref a la pos del jugador y al mismo
    public Vector3 spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        //Buscamos todos los GameObjects que tengan el script asociado Checkpoint y los guardamos en nuestro array
        _checkpoints = GetComponentsInChildren<Checkpoint>();

        spawnPoint = GameObject.Find("Player").transform.position;
    }



    public void DeactivateCheckpoints()
    {
        //Hacemos un bucle que pase por todos los checkpoints almacenados en el array
        foreach (Checkpoint c in _checkpoints)
        {

            c.ResetCheckpoint();
        }

    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

}

