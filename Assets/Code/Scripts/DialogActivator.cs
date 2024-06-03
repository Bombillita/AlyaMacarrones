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
    public bool isShop = false;
    public bool isInteractableObj = false;


    public static DialogActivator instance;
    private DialogueManager _dmRef;

    void Start()
    {
        _pcref = GameObject.Find("Player").GetComponent<PlayerC>();
        _dmRef = GameObject.Find("Canvas").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador puede activar el diálogo y presiona el botón de interacción y la caja de diálogo no está activa en la jerarquía
        if (canActivate && Input.GetKeyDown(KeyCode.E) && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            _dmRef.isInteractableObj = isInteractableObj;
            _dmRef.isShop = isShop;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivate = false;
    }
}