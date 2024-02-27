using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    //refs a los sprites que iran cambiando al activar y desactivar
    public Animator cpOn, cpOff;
    //Ref al sprite rednerer del cp
    private SpriteRenderer _sR;
    //Refe a cpcontroller
    private CheckpointController _cReference;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        //iniciamos las refs
        _sR = GetComponent<SpriteRenderer>();
        //_cReference = GameObject.Find("CheckpointController").GetComponent<CheckpointController>(); ; forma más sencilla:
        _cReference = transform.parent.GetComponent<CheckpointController>();
        _anim = GetComponent<Animator>();
    }

    //Saber si el jugador ha entrado en la zona del cp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            //Desactivamos cp anteriores
            _cReference.DeactivateCheckpoints();
            //Cambia el sprite del activo
            _anim.SetTrigger("checkpoint");
            //Guarda la pos del cp para el spawn
            _cReference.SetSpawnPoint(transform.position);
        }
    }

    //para desactivar el cp concreto
    public void ResetCheckpoint()
    {

        _anim = cpOff;
    }
}



