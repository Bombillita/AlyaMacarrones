using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;
    public float showGameOver;
    private LevelManager _lReference;
   

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
        yield return new WaitForSeconds(showGameOver);

        MenuGameOver.SetActive(true);
    }


    //M�TODOS
    public void Continue()
    {
        _lReference.RespawnPlayer();
        MenuGameOver.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        MenuGameOver.SetActive(false);
    }


}
