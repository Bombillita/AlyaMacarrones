using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    //refs
    public Animator animpuerta;
    private SpriteRenderer _sr;
    private LevelManager _lReference;
    private bool _canOpenDoor = false;


    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        animpuerta = GetComponent<Animator>();
    }

    void Update()
    {

        //para que compruebe que si la puerta esta abierta
        if (Input.GetKeyDown(KeyCode.F) && _canOpenDoor == true)
        {
            animpuerta.SetTrigger("pliopen");
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canOpenDoor = true;
        }
    }

    //hay que poner que cuando salga del trigger que sea falso
    private void OnTriggerExit2D(Collider2D collision)
    {
        _canOpenDoor = false;
    }
}
