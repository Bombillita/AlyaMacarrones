using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //Referenciamos el collider de la plataforma
    Collider2D _platformCollider;
    bool _onPlatform = false;

   
    void Start()
    {
        //collider
        _platformCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos abajo y estamos sobre la plataforma
        if (Input.GetAxisRaw("Vertical") < -0.5f && _onPlatform)
        {
            
            StartCoroutine(ActDeactPlatformCo());
        }
    }

   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
            _onPlatform = true;
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _onPlatform = false;
    }

    //Corrutina que activa y desactiva el collider de la plataforma
    private IEnumerator ActDeactPlatformCo()
    {
        //Desactivamos el componente collider
        _platformCollider.enabled = false; 
        yield return new WaitForSeconds(.5f);
        _platformCollider.enabled = true;
    }

   
}


