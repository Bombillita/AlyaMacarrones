using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatOnTrigger : MonoBehaviour
{
    public static bool istutorial = true;
    private LevelUIController _uiRef;

    private void Start()
    {
        _uiRef = GameObject.Find("Canvas").GetComponent<LevelUIController>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadCombat());
        }

    }

    private IEnumerator LoadCombat()
    {
        _uiRef.FadeToBlack();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Battle");
    }


}
