using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public Text dialogText;
    public Image portrait;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;
    private string charName;
    private Sprite sNpc;

    //Hacemos una referencia (Singleton)
    public static DialogueManager instance;
    private void Awake()
    {
        //Inicializamos el Singleton si est� vac�o
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    { 
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Si el di�logo no ha empezado ahora mismo
                if (!justStarted)
                {
                    //Vamos a la siguiente l�nea de di�logo
                    currentLine++;

                    //Si se ha terminado el di�logo
                    if (currentLine >= dialogLines.Length)
                    {
                        //Desactivamos el cuadro de di�logo
                        dialogBox.SetActive(false);
                        PlayerC.instance.interacting = false;
                    }
                    //Si el di�logo a�n no ha terminado
                    else
                    {
                        //Comprobamos si hay un cambio de personaje en el di�logo
                        CheckIfName(sNpc);
                        //Muestra la l�nea de di�logo actual
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                //Si el di�logo ya empez�
                else
                    justStarted = false;
            }
        }
    }

    //M�todo que muestra el di�logo pasado por par�metro
    public void ShowDialog(string[] newLines, Sprite theSNpc)
    {
        //El contenido de las l�neas de di�logo del Manager pasa a ser el de las l�neas de di�logo tras haber activado un di�logo
        dialogLines = newLines;
        //Vamos a la primera l�nea de di�logo
        currentLine = 0;
        //Asignamos el Sprite del NPC
        sNpc = theSNpc;
        //Comprobamos si hay un cambio de personaje en el di�logo
        CheckIfName(sNpc);
        //Muestro la l�nea de di�logo actual
        dialogText.text = dialogLines[currentLine];
        //Activamos el cuadro de di�logo
        dialogBox.SetActive(true);
        //El di�logo acaba de empezar
        justStarted = true;
        //Hacemos que el jugador no se pueda mover
        PlayerC.instance.interacting = true;
    }

    //M�todo para conocer si hay un cambio de personaje en el di�logo
    public void CheckIfName(Sprite theSNpc)
    {
        //Si la l�nea empieza por n-
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            //Obtenemos el nombre del personaje que habla en ese momento
            charName = dialogLines[currentLine].Replace("n-", "");
            //Si es distinto de los nombres de los personajes principales
            if (charName != "Alya")
                //Ponemos el sprite del npc en concreto
                portrait.sprite = theSNpc;
            //Si es el nombre de un personaje principal
            else
                //Ponemos el sprite de ese personaje
                portrait.sprite = PlayerC.instance.PlayerSprite;

            //Salto a la siguiente l�nea de di�logo
            currentLine++;
        }
    }
}
