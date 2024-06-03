using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Animator cpOn, cpOff;
    private SpriteRenderer _sR;
    private CheckpointController _cReference;
    private Animator _anim;
    public bool cpActive = false;

    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        _cReference = transform.parent.GetComponent<CheckpointController>();
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cpActive = true;
            _cReference.DeactivateCheckpoints();
            _anim.SetTrigger("checkpoint");
            _cReference.SetSpawnPoint(transform.position);
            cpActive = true;
        }
        else
        {
            cpActive = false;
        }
    }


    public void ResetCheckpoint()
    {
        cpActive = false;
        _anim = cpOff;
    }
}



