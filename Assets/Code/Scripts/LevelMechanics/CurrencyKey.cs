using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyKey : MonoBehaviour
{
    public int currencyneeded;
    private Puerta _pRef;
    private bool _doorenabled = false;
    private UIController _uiC;
    private bool _moneyytaken = false;
    //[SerializeField] TMPro.TextMeshPro _txt;

    private void Start()
    {
        _pRef = GameObject.Find("puerta").GetComponent<Puerta>();
        _uiC = GameObject.Find("Canvas").GetComponent<UIController>();
    }


    void Update()
    {
        if (_pRef._canOpenDoor == true)
        {
            _doorenabled = true;
        }
        else
        {
            _doorenabled = false;
        }


        if (_doorenabled == true && LevelManager.moneycollected >= currencyneeded && Input.GetKeyDown(KeyCode.E))
        {
            _pRef.LoadLevel(_pRef.levelToLoad);
           

            if (!_moneyytaken)
            {
                LevelManager.moneycollected -= currencyneeded;
                _uiC.UpdateCurrency();
                _moneyytaken = true;
            }   
        }

    }


}
