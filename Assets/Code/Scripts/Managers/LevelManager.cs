using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Variable de tiempo para la corrutina
    public float waitToRespawn;

    //Refs
    private PlayerC _pCReference;
    private CheckpointController _cReference;
    private UIController _uIReference;
    private PlayerHealthController _pHReference;
    private Puerta _puertaRef, _puertaRef2, _puertaRef3;
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
        _puertaRef = GameObject.Find("puerta").GetComponent<Puerta>();
       /* _puertaRef2 = GameObject.Find("puerta2").GetComponent<Puerta>();
        _puertaRef3 = GameObject.Find("puerta3").GetComponent<Puerta>();*/

    }

    //RESPAWN
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
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
    public IEnumerator ExitLevelCo()
    {
        //Fundido a negro
        _lUIController.FadeToBlack();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SampleScene");

      /*  if (_puertaRef.n == 0)
        {
            SceneManager.LoadScene(_puertaRef.levelToLoad);
        }

        if (_puertaRef2.n == 1)
        {
            SceneManager.LoadScene(_puertaRef2.levelToLoad);
        }

        if (_puertaRef3.n == 2)
        {
            SceneManager.LoadScene(_puertaRef3.levelToLoad);
        } */

    }
}
