using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    Collider2D _platformCollider;
    //variable que permite bajar de la plataforma si estamos sobre ella
    bool _onplatform = false;

    // Start is called before the first frame update
    void Start()
    {
        //inicializa el collider de la plataforma
        _platformCollider = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //si pulsamos abajo
        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            _platformCollider.enabled = false; //ENABLE PERMITE ACTIVAR O DESACTIVAR UN COMPONENTE ESPECÍFICO DEL OBJETO. como no quiero que se desactive para siempre, corutina
            StartCoroutine(ActDeactPlatformCo());
        }

    }

    //Metodo para que si le das abajo en plataformas one way, te envie abajo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    //mientras un collider toque al de el objeto
    private void OnCollisionStay2D(Collision2D collision)
    {
        //en los collision no detecta comparetag, poner gameobject.
        if (collision.gameObject.CompareTag("Player"))
        {
            _onplatform = true;
        }
        //para saber cuadno algo ha dejado de colisionar
    }

    private IEnumerator ActDeactPlatformCo()
    {
        _platformCollider.enabled = false;
        //esperamos tiempo especfifico
        yield return new WaitForSeconds(.5f);
        _platformCollider.enabled = true;

    }

}
