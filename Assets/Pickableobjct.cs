using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickableobjct : MonoBehaviour
{
    private SpriteRenderer _sr;
    [SerializeField] Collider2D _collider;

    public bool ontriggerMAZNZAAA = false;

    public bool PickedUp = false;
    private CombatOnTrigger _bsRef;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bsRef = GameObject.Find("entradacueva").GetComponent<CombatOnTrigger>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ontriggerMAZNZAAA = true;

        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PickedUp = true;
            Debug.Log("Ya esta picha");
            _sr.enabled = false;
            _collider.enabled = false;
            _bsRef.enabled = true;
        }
       
    }

    private void Update()
    {
       /* if (PickedUp == true)
        {
            Debug.Log("Ya esta picha");
            _sr.enabled = false;
            _collider.enabled = false;
            _bsRef.enabled = true;
        }*/
    }
}

   
