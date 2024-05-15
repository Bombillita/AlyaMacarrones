using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivation : MonoBehaviour
{
    [SerializeField] private GameObject Shop;
    private DialogueManager _dmRef;
    private PauseMenu _pMenuRef;
    private PlayerC _pCRef;
    private bool _openShop = false;

    private void Start()
    {
        _pCRef = GameObject.Find("Player").GetComponent<PlayerC>();
        _dmRef = GameObject.Find("Canvas").GetComponent<DialogueManager>();
    }
    private void Awake()
    {
        _pMenuRef = GameObject.Find("LevelManager").GetComponent<PauseMenu>();
    }
 
    void Update()
    {
        if (_dmRef.canOpenShop == true)
        {
            ShopOpened();
            DialogActivator.instance.canActivate = false;
        }
        else
        {
            Continue();
            DialogActivator.instance.canActivate = true;
        }

        if (_openShop == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void ShopOpened()
    {
        _pMenuRef.enabled = false;
        Shop.SetActive(true);
        _pCRef.enabled = false;
        Time.timeScale = 0f;
        _openShop = true;
    }

    public void Continue()
    {
        _dmRef.canOpenShop = false;
        _pMenuRef.enabled = true;
        Shop.SetActive(false);
        _pCRef.enabled = true;
        Time.timeScale = 1f;
        _openShop = false;
    }
  
}


