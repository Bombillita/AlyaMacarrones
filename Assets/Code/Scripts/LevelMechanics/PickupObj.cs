using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{

    public bool isGem, isHeal, isObj;
    private bool _isCollected;




    //Referencia al LevelManager
    private LevelManager _lMReference;
    //Referencian al UIController
    private UIController _uIReference;
    //Referencia al PlayerHealthController
    private PlayerHealthController _pHReference;
    private bool _canCollect = false;
    private inventory _inventoryRef;

    //para el inventario
    public GameObject item;

    private void Start()
    {
        //Inicializamos la referencia al UIController
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        //Inicializamos la referencia al PlayerHealthController
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _inventoryRef = GameObject.Find("LevelManager").GetComponent<inventory>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isCollected && Input.GetKey(KeyCode.E))
        {
            _canCollect = true;

            if (isGem && _canCollect == true)
            {
                LevelManager.moneycollected++;
                _uIReference.UpdateCurrency();
                _isCollected = true;
                Destroy(gameObject);
            }
            else { _isCollected = false; }

            if (isHeal && _canCollect == true)
            {
                if (_pHReference.currentHealth != _pHReference.maxHealth)
                {
                    _pHReference.HealPlayer();
                    _isCollected = true;
                    Destroy(gameObject);
                }
                else { _isCollected = false; }

            }
            else
            {
                _canCollect = false;
            }

            if (isObj && _canCollect == true)
            {
                //si los slots estan vacios
                for (int i = 0; i < _inventoryRef.slots.Length; i++)
                {
                    if (_inventoryRef.isFull[i] == false)
                    { //se puede añadir objeto
                        _inventoryRef.isFull[i] = true;
                        break;
                    }
                }
            }
        }
    }
}






