using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    //array para guardar los cp de la escena
    private Checkpoint[] _checkpoints;

    //ref a la pos del jugador y al mismo
    public Vector3 spawnPoint;
    private GameObject _alya;


    // Start is called before the first frame update
    void Start()
    {
        //Buscamos todos los GameObjects que tengan el script asociado Checkpoint y los guardamos en nuestro array
        _checkpoints = GetComponentsInChildren<Checkpoint>();

        //pso inicial de l jugador por si no hemos guardado ningun cp
        spawnPoint = GameObject.Find("Alya").transform.position;
    }


    void Update()
    {

    }

    //M?todo para desactivar los checkpoints
    public void DeactivateCheckpoints()
    {
        //Hacemos un bucle que pase por todos los checkpoints almacenados en el array
        foreach (Checkpoint c in _checkpoints)
        {

            //Hace el m?todo de resetear ese Checkpoint concreto
            c.ResetCheckpoint();


        }

    }

    //M?todo para generar el punto de reaparici?n del jugador
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        //El punto de spawn del jugador ser? el del checkpoint activo que le pasemos
        spawnPoint = newSpawnPoint;
    }

}

