using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivation : MonoBehaviour
{
    private DialogueManager _dmRef;
    [SerializeField] private GameObject Shop;
    private bool _openShop = false;
    public PlayerC _pCref;

    // Start is called before the first frame update
    void Start()
    {
        _dmRef = GameObject.Find("Canvas").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dmRef.hasinteracted == true && Input.GetKeyDown(KeyCode.E))
        {
            ShopOpened();
            DialogActivator.instance.canActivate = false;
        }
        else
        {
            Continue();
            DialogActivator.instance.canActivate = true;
        }
    }

    public void ShopOpened()
    {
        _pCref.enabled = false;
        Time.timeScale = 0f;
        Shop.SetActive(true);
        _openShop = true;
    }

    public void Continue()
    {
        Shop.SetActive(false);
        _openShop = false;
        _pCref.enabled = true;
        Time.timeScale = 1f;

    }

}
