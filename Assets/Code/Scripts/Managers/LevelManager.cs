using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Variable de tiempo para la corrutina
    public float waitToRespawn;
    public float showGameOver;

    //Refs
    private PlayerC _pCReference;
    private CheckpointController _cReference;
    private UIController _uIReference;
    private PlayerHealthController _pHReference;
    //metodo para salir del nivel
    private LevelUIController _lUIController;
   

    private void Start()
    {
        //Inicializamos las refs
        _pCReference = GameObject.Find("Player").GetComponent<PlayerC>();
        _cReference = GameObject.Find("CheckPointController").GetComponent<CheckpointController>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _lUIController = GameObject.Find("Canvas").GetComponent<LevelUIController>();


    }

    //RESPAWN
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());      
    }

    //Corrutina
    private IEnumerator RespawnPlayerCo()
    {
        //Desactivamos al jugador
        _pCReference.gameObject.SetActive(false);
        //Esperamos un tiempo
        yield return new WaitForSeconds(waitToRespawn);
        //Reactivamos al jugador
        _pCReference.gameObject.SetActive(true);
        //Pos de respawm
        _pCReference.transform.position = _cReference.spawnPoint;
        //Vida del jugador al máximo
        _pHReference.currentHealth = _pHReference.maxHealth;
        //Actualizar UI
        _uIReference.UpdateHealthDisplay();
    }


    //Corrutina salir del nivel 
    public IEnumerator ExitLevelCo(int scene)
    {
        //Fundido a negro
        _lUIController.FadeToBlack();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);

    }

    public IEnumerator ExitSceneCo(int scene)
    {
        //Fundido a negro
        _lUIController.FadeToBlack();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);

    }
}
