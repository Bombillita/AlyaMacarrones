using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    private bool canActivate;
    public Sprite theNpcSprite;

    void Start()
    {

    }

    void Update()
    {
        //Si el jugador puede activar el di�logo y presiona el bot�n de interacci�n y la caja de di�logo no est� activa en la jerarqu�a
        if (canActivate && Input.GetKeyDown(KeyCode.F) && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            //Llamamos al m�todo que muestra el di�logo y le pasamos las l�neas concretas que contiene este objeto
            DialogueManager.instance.ShowDialog(lines, theNpcSprite);
        }
    }

    //Si el jugador entra en la zona de Trigger puede activar el di�logo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = true;
    }

    //Si el jugador sale de la zona de Trigger ya no puede activar le di�logo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = false;
    }
}


