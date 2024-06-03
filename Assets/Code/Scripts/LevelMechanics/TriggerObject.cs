using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    private DialogueManager _dmRef;
    public static bool triggerOn = false;
    [SerializeField] Animator _anim;
    private DestroyIfInteracted _diRef;
    private DestroyOverTime _destroyObjRef;
    public static bool _destroyed = false;

    private void Start()
    {
        _dmRef = GameObject.Find("Canvas").GetComponent<DialogueManager>();
        _diRef = GameObject.Find("Checkpoint").GetComponent<DestroyIfInteracted>();
        _destroyObjRef = GameObject.Find("muraco").GetComponent<DestroyOverTime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _dmRef.canOpenShop == true)
        {
            triggerOn = true;
        }
        else
        {
            triggerOn = false;
        }
    }

    private void Update()
    {
        if (_diRef.isDestroying == true)
        {
            _destroyObjRef.enabled = true;
            _anim.SetTrigger("explosion");
            _destroyed = true;
        }
        else
        {
            _destroyed = false;
            _destroyObjRef.enabled = false;
        }

    }
}
