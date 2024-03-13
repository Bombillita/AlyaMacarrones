using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnyController : MonoBehaviour
{
  /*  //referencias
    private PlayerC _pCReference;
    private Animator _anim;
    private Rigidbody2D _theRb;
    private SpriteRenderer _sr;

    //variables
    public float dashDuration;
    public float dashForce;

    // Start is called before the first frame update
    void Start()
    {
        _pCReference = GetComponent<PlayerC>();
        _anim = GetComponent<Animator>();
        _theRb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //StartCoroutine(DashCo());
        }
    }

    /* private IEnumerator DashCo()
    { 
        

    } */
}
