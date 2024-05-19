using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject[] items;
    public Transform itemContainer;
    public GameObject itemTemplate;
   

    //refs
    private LevelManager _lMRef;
    public StoreItem _sIRef;
    private UIController _uIReference;

    private void Start()
    {
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    private void Awake()
    {
        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        
    }

    public void buyItem()
    {
        if (LevelManager.moneycollected >= _sIRef.price)
        {
            LevelManager.moneycollected -= _sIRef.price;
            _uIReference.UpdateCurrency();
        }
        else
        {
            Debug.Log("Pobre");
        }
    }
}
