using UnityEngine;
using System.Collections;

public class PushableObject : MonoBehaviour
{

    public bool canPush = false;
    private Rigidbody2D _rb;
    private PlayerC _pCref;
    //public GameObject info;


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
            _rb.mass = 25.0f;
        }
        else
        {
            _pCref.canRun = true;
            _rb.mass = 100.0f;
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

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(info);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(info);
        }
    } */


}