using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameVisual : MonoBehaviour
{
    public bool isend = false;

    [SerializeField] TextMeshProUGUI textComponent;

    State stateRef;

    [SerializeField] State startingState;

    public GameObject Background;
    public Image imagen;

    void Start()
    {

        stateRef = startingState;

        textComponent.text = stateRef.GetStateStoryText();

        imagen = Background.GetComponent<Image>();

        imagen.sprite = stateRef.GetStateImage();

    }

    // Update is called once per frame
    void Update()
    {

        ManageStates();
    }


    void ManageStates()
    {

        State[] nextStates = stateRef.GetNextStates();

        if (nextStates.Length == 0)
        {
            if (isend == false)
            {
                SceneManager.LoadScene("CasaAlya");
                return;
            }
            if (isend == true)
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateRef = nextStates[0];
        }


        textComponent.text = stateRef.GetStateStoryText();

        imagen.sprite = stateRef.GetStateImage();

       
    }
}
