using UnityEngine;
using System.Collections;

public class PushableObject : MonoBehaviour
{

    public bool canPush = false;
    private bool pushing = false;
    private Rigidbody2D _rb;
    private PlayerC _pCref;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pCref = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && canPush == true)
        {
            _pCref.canRun = false;
            _rb.mass = 30.0f;
            pushing = true;
        }
        else
        {
            _pCref.canRun = true;
            _rb.mass = 100.0f;
            pushing = false;
        }

       

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPush = true;
        }
        else
        {
            canPush = false;
        }
    }

    
}
