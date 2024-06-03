using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public bool isFull = false;
    [SerializeField] public GameObject inventory;
    [SerializeField] public GameObject Menupausa;

    //referencias
    private PauseMenu _pMenuRef;
    private PlayerC _pCRef;
    public bool inventoryOpen = false;
    public static Inventory instance;

    //public List<InventoryItem> items = new List<InventoryItem>();

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

        if (inventoryOpen == true)
        {
            Menupausa.SetActive(false);
        }
    
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
        _pCRef.enabled = false;
        _pMenuRef.enabled = false;
        inventory.SetActive(true);
        Time.timeScale = 0f;      
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        _pCRef.enabled = true;
        _pMenuRef.enabled = true;
        inventory.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddItem()
    {

    }
}
