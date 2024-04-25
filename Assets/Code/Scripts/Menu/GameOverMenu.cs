using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;
    private LevelUIController _uIReference;
    public float showGameOver;
    private PlayerHealthController _pHController;
    private LevelManager _lReference;
   

    private void Start()
    {
        _uIReference = GameObject.Find("Canvas").GetComponent<LevelUIController>();
        _pHController = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    private void Awake()
    {
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }


    //corutina
    public void GameOver()
    {
        StartCoroutine(GameOverCo());
    }

    private IEnumerator GameOverCo()
    {
        _uIReference.FadeToBlack();

        yield return new WaitForSeconds(showGameOver);

        MenuGameOver.SetActive(true);
    }


    //MÉTODOS
    public void Continue()
    {
        _lReference.RespawnPlayer();
        MenuGameOver.SetActive(false);
        _uIReference.FadeFromBlack();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        MenuGameOver.SetActive(false);
    }


}
