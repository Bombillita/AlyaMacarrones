using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    [SerializeField] private GameObject Inventory;

    //referencias
    private PauseMenu _pMenuRef;
    private PlayerC _pCRef;
    public bool inventoryOpen = false;

    private void Start()
    {
        _pCRef = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    private void Awake()
    {
        _pMenuRef = GameObject.Find("LevelManager").GetComponent<PauseMenu>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }

        if (inventoryOpen == true && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
        _pCRef.enabled = false;
        _pMenuRef.enabled = false;
        Inventory.SetActive(true);
        Time.timeScale = 0f;      
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        _pCRef.enabled = true;
        _pMenuRef.enabled = true;
        Inventory.SetActive(false);
        Time.timeScale = 1f;
    }
}
