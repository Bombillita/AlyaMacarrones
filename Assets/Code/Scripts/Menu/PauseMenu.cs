using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPausa;

    private bool _pausedGame = false;
    private Inventory _invRef;
    public PlayerC _pCref;

    private void Start()
    {
        _pCref = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    private void Awake()
    {
        _invRef = GameObject.Find("LevelManager").GetComponent<Inventory>();
    }

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
        _pCref.enabled = false;
        Time.timeScale = 0f;
        MenuPausa.SetActive(true);
        _pausedGame = true;
    }

    public void Reanudar()
    {
        MenuPausa.SetActive(false);
        _pausedGame=false;
        _pCref.enabled = true;
        Time.timeScale = 1f;

    }

    public void Objetos()
    {
        Time.timeScale = 0f;
        MenuPausa.SetActive(false);
        _invRef.OpenInventory();
    }

    public void Quit()
    {
        Debug.Log("adios");
        Application.Quit();
    }
}
