using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //La caja de texto para el diálogo
    public TextMeshProUGUI dialogText;
    //El retrato del personaje que habla en ese momento
    public Image portrait;
    //Referencia a la caja de diálogos
    public GameObject dialogBox;
    //Líneas del diálogo
    public string[] dialogLines;
    //La línea actual de diálogo
    public int currentLine;
    //Para saber si acaba de empezar o no
    private bool justStarted;
    //Nombre del personaje que habla en ese momento
    private string charName;
    //El sprite del NPC
    private Sprite sNpc;
    private PlayerC _pCreference;

    //Hacemos una referencia (Singleton)
    public static DialogueManager instance;
    private void Awake()
    {
        //Inicializamos el Singleton si está vacío
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _pCreference = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el cuadro de diálogo está activo
        if (dialogBox.activeInHierarchy)
        {
            //Al pulsar la tecla X
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Si el diálogo no ha empezado ahora mismo
                if (!justStarted)
                {
                    //Vamos a la siguiente línea de diálogo
                    currentLine++;

                    //Si se ha terminado el diálogo
                    if (currentLine >= dialogLines.Length)
                    {
                        //Desactivamos el cuadro de diálogo
                        dialogBox.SetActive(false);
                        //Permitimos que el jugador se mueva de nuevo
                        PlayerC.instance.canMove = true;


                    }
                    //Si el diálogo aún no ha terminado
                    else
                    {
                        //Comprobamos si hay un cambio de personaje en el diálogo
                        CheckIfName(sNpc);
                        //Muestra la línea de diálogo actual
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                //Si el diálogo ya empezó
                else
                    justStarted = false;
            }
        }
    }

    //Método que muestra el diálogo pasado por parámetro
    public void ShowDialog(string[] newLines, Sprite theSNpc)
    {
        //El contenido de las líneas de diálogo del Manager pasa a ser el de las líneas de diálogo tras haber activado un diálogo
        dialogLines = newLines;
        //Vamos a la primera línea de diálogo
        currentLine = 0;
        //Asignamos el Sprite del NPC
        sNpc = theSNpc;
        //Comprobamos si hay un cambio de personaje en el diálogo
        CheckIfName(sNpc);
        //Muestro la línea de diálogo actual
        dialogText.text = dialogLines[currentLine];
        //Activamos el cuadro de diálogo
        dialogBox.SetActive(true);
        //El diálogo acaba de empezar
        justStarted = true;
        //Hacemos que el jugador no se pueda mover
        PlayerC.instance.canMove = false;



    }

    //Método para conocer si hay un cambio de personaje en el diálogo
    public void CheckIfName(Sprite theSNpc)
    {
        //Si la línea empieza por n-
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            //Obtenemos el nombre del personaje que habla en ese momento
            charName = dialogLines[currentLine].Replace("n-", "");
            //Si es distinto de los nombres de los personajes principales
            if (charName != "Player")
                //Ponemos el sprite del npc en concreto
                portrait.sprite = theSNpc;
            //Si es el nombre de un personaje principal
            else
                //Ponemos el sprite de ese personaje
                portrait.sprite = _pCreference.PlayerSprite;

            //Salto a la siguiente línea de diálogo
            currentLine++;
        }
    }
}