using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivation : MonoBehaviour
{
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject infopanelalt;
    private DialogueManager _dmRef;
    private PauseMenu _pMenuRef;
    private PlayerC _pCRef;
    private Inventory _iRef;
    private bool _openShop = false;
   
    //private Shop _shopRef;

    private void Start()
    {
        _pCRef = GameObject.Find("Player").GetComponent<PlayerC>();
        _dmRef = GameObject.Find("Canvas").GetComponent<DialogueManager>();
    }
    private void Awake()
    {
        _pMenuRef = GameObject.Find("LevelManager").GetComponent<PauseMenu>();
        _iRef = GameObject.Find("LevelManager").GetComponent<Inventory>();
    }
 
    void Update()
    {
        if (_dmRef.canOpenShop == true)
        {
            ShopOpened();
            
        }
        else
        {
            Continue();
            
        }

        if (_dmRef.canOpenShop == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }

        if (_openShop == true)
        {
            infopanelalt.SetActive(false);
        }
    }

    public void ShopOpened()
    {
        _dmRef.canOpenShop = true;
        _pMenuRef.enabled = false;
        Shop.SetActive(true);
        _iRef.enabled = false;
        _pCRef.enabled = false;
        Time.timeScale = 0f;
        _openShop = true;
        //_shopRef.enabled = true;
    }

    public void Continue()
    {
        _dmRef.canOpenShop = false;
        _pMenuRef.enabled = true;
        _iRef.enabled = true;
        Shop.SetActive(false);
        _pCRef.enabled = true;
        Time.timeScale = 1f;
        _openShop = false;
        //_shopRef.enabled = false;
    }
  
}


