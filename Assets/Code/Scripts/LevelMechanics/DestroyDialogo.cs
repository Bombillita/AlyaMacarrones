using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDialogo : MonoBehaviour
{
    public string[] lines;
    public bool canActivatea;
    public Sprite theNpcSprite;
    public bool dialogueActive = false;
    private PlayerC _pcref;
    public bool isShop = false;
    public bool isInteractableObj = false;
    public bool dialoguecanBeActive = false;


    [SerializeField] BoxCollider2D objetodialogoA;
    public static DestroyDialogo instance;
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
        if (canActivatea && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            dialoguecanBeActive = true;
            objetodialogoA.enabled = false;
            
        }
        else
        {
            dialoguecanBeActive = false;
        }


        if (DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            canActivatea = false;
            dialogueActive = true;
            _pcref.enabled = false;
            
        }
        else
        {
            dialogueActive = false;
            _pcref.enabled = true;
        }


        if (dialoguecanBeActive == true)
        {
            dialoguecanBeActive = false;
            _dmRef.isInteractableObj = isInteractableObj;
            _dmRef.isShop = isShop;
            DialogueManager.instance.ShowDialog(lines, theNpcSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivatea = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canActivatea = false;
    }
}