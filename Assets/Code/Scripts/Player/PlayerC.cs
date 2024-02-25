using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    //Variable para saber si el jugador está en el suelo
    private bool _isGrounded;
    //Referencia al punto por debajo del jugador que tomamos para detectar el suelo
    public Transform groundCheckPoint;
    //Referencia para detectar el Layer de suelo
    public LayerMask whatIsGround;
    //private bool _canDoubleJump;

    //componentes
    private Rigidbody2D _theRB;
    private Animator _anim;
    private SpriteRenderer _theSR;

    // Start is called before the first frame update
    void Start()
    {
        _theRB = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _theRB.velocity.y);

        //Variable true siempre que el círculo físico esté en contacto con el suelo. Overlapcircle punto donde se genera, radio, layer a detectar
       
        _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (Input.GetButton("Jump"))
            {
            if (_isGrounded)
            {
                _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                //podemos activar la posibilidad de doble salto
                //_canDoubleJump = true;
            }
            //si no está en el suelo
            /* else
            {
                if (_canDoubleJump)
                {
                   _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                    //evitar 3 salto
                    _canDoubleJump = false; 
                }
            }*/
        }


        //Girar el sprite dle jugador según su dirección
        //IZquierda
        if (_theRB.velocity.x < 0)
        {
            _theSR.flipX = false;
        }
        //Derecha
        else if (_theRB.velocity.x > 0)
        {
            _theSR.flipX = true;
        }

        //ANIMACIONES
        _anim.SetFloat("moveSpeed", Mathf.Abs(_theRB.velocity.x));
        //Mathf.Abs hace que un valor negativo sea positivo, lo que nos permite que al movernos a la izquierda también se anime esta acción
        _anim.SetBool("isGrounded", _isGrounded);
    }
}
