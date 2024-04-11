using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    public int levelToLoad;
    private LevelManager _lReference;
    private PlayerC _pCRef;

    private void Awake()
    {
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Start()
    {
        _pCRef = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            LoadScene(levelToLoad);
            _pCRef.interacting = true;
        }
    }

    private void LoadScene(int n)
    {
        StartCoroutine(_lReference.ExitSceneCo(n));
    }
}
