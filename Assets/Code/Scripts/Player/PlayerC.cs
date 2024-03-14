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
    public float knockBackForce;
    public float knockBackLength; //contador
    private float _knockBackCounter;
    public bool seeLeft; //donde esta mirando
    public float runMode;
    private bool _isRunning;

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

        //KNOCKBACK
        if (_knockBackCounter <= 0)
        {

            //FLIP DEL SPRITE y movimiento
            _theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _theRB.velocity.y);

            //CORRER

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * runMode, _theRB.velocity.y);
                _anim.SetBool("isRunning", true);

            }
            else
            {
                _theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _theRB.velocity.y);
                _anim.SetBool("isRunning", false);
            }


            if (_theRB.velocity.x < 0)
            {

                _theSR.flipX = false;
                seeLeft = true;
            }
            //dcha
            else if (_theRB.velocity.x > 0)
            {

                _theSR.flipX = true;
                seeLeft = false;
            }

            //Variable true siempre que el círculo físico esté en contacto con el suelo. Overlapcircle punto donde se genera, radio, layer a detectar

            _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (Input.GetButton("Jump"))
            {
               
                        if (_isGrounded)
                        {
                            //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                            _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                            //Una vez en el suelo, reactivamos la posibilidad de doble salto
                            //_canDoubleJump = true;
                        }
                        //Si el jugador no está en el suelo
                        /*else
                        {
                            //Si canDoubleJump es verdadera
                            if (_canDoubleJump)
                            {
                                //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                                _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                                //Hacemos que no se pueda volver a saltar de nuevo
                                _canDoubleJump = false;
                            }
                        } */
            }
                   
                   
        }
                //Contador ed knockback aun no esta vacio
                else
                {
                    //Detener el contador en 1 cada sec
                    _knockBackCounter -= Time.deltaTime;
                    //Si el jugador mira a la izquierda
                    if (!_theSR.flipX)
                        //Empuje a dhca
                        _theRB.velocity = new Vector2(knockBackForce, _theRB.velocity.y);
                    //Si el jugador mira a la derecha
                    else
                        //Empuje izda
                        _theRB.velocity = new Vector2(-knockBackForce, _theRB.velocity.y);
                }
            


            //ANIMACIONES
            _anim.SetFloat("moveSpeed", Mathf.Abs(_theRB.velocity.x));
            //Mathf.Abs hace que un valor negativo sea positivo, lo que nos permite que al movernos a la izquierda también se anime esta acción
            _anim.SetBool("isGrounded", _isGrounded);
        

        
    }

    //Método de knockback
    public void Knockback()
    {
        //Inicializamos el contador de KnockBack
        _knockBackCounter = knockBackLength;
        //Paralizamos al jugador en X y hacemos que salte en Y
        _theRB.velocity = new Vector2(0f, knockBackForce);
        //Cambiamos el valor del parámetro del Animator "hurt"
        _anim.SetTrigger("hurt");
    }
}
