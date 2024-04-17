using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    //pa la ui
    public Text dialogText;
    public Image portrait;
    public GameObject dialogBox;
    public string[] dialogLines;
    public int currentLine;
    public bool justStarted;
    private string charName;
    private Sprite sNpc;

    public static Dialoguemanager.instance;
    // Start is called before the first frame update
    private void Awake()
    {


    }

    private void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        //hacer que el player no se mueva
                    }
                }
            }
        }
    }
    
    public void CheckIfName(Sprite theSNpc)
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            charName = dialogLines[currentLine].Replace("n-", "");
            if (charName != "Alya")
            {
                portrait.sprite = theSNpc;
            }
            else
            {
                portrait.sprite = PlayerC.instance.thePlayerSprite;
                currentLine++;
            }
        }
    }
    public void ShowDialog(string[] newLines, Sprite theSNpc)
    {
        dialogLines = newLines;
        currentLine = 0;
        sNpc = theSNpc;
        CheckIfName
    }
}
