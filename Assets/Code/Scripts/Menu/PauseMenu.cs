using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPausa;

    private bool _pausedGame = false;

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pausedGame)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
        
    }

    //metodos
    public void Pausa()
    {
        Time.timeScale = 0f;
        MenuPausa.SetActive(true);
        _pausedGame = true;

    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        MenuPausa.SetActive(false);
        _pausedGame=false;
    }

    public void Objetos()
    {
        Time.timeScale = 1f;
        MenuPausa.SetActive(false);
        _pausedGame = false;
    }

    public void Quit()
    {
        Debug.Log("adios");
        Application.Quit();
    }
}
