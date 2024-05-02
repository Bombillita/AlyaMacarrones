using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    //Líneas del diálogo
    public string[] lines;
    //Para saber si el diálogo se puede activar o no
    public bool canActivate;
    //Sprite de diálogo del NPC
    public Sprite theNpcSprite;
    public bool dialogueActive = false;
    private PlayerC _pcref;
    

    public static DialogActivator instance;

    // Start is called before the first frame update
    void Start()
    {
        _pcref = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador puede activar el diálogo y presiona el botón de interacción y la caja de diálogo no está activa en la jerarquía
        if (canActivate && Input.GetKeyDown(KeyCode.E) && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialog(lines, theNpcSprite);  
        }

        if (DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            dialogueActive = true;
            _pcref.enabled = false;
        }
        else
        {
            dialogueActive = false;
            _pcref.enabled = true;
        }

    }

    //Si el jugador entra en la zona de Trigger puede activar el diálogo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = true;

    }

    //Si el jugador sale de la zona de Trigger ya no puede activar le diálogo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = false;
    }
}