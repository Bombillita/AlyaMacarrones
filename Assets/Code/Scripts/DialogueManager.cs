using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public Image portrait;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;
    private string charName;
    private Sprite sNpc;
    private PlayerC _pCreference;
    public static DialogueManager instance;
    public bool hasinteracted = false;

    private void Awake()
    {
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
       
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                if (!justStarted)
                {

                    currentLine++;


                    if (currentLine >= dialogLines.Length)
                    {
                        //Desactivamos el cuadro de diálogo
                        dialogBox.SetActive(false);
                        //Permitimos que el jugador se mueva de nuevo
                        PlayerC.instance.canMove = true;
                        hasinteracted = true;


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