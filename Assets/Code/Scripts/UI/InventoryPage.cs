using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] InventoryItem itemPrefab;
    [SerializeField] RectTransform contentPanel;
    [SerializeField] private InventoryDescription itemDescription;

    List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public Sprite img;
    public int price;
    public string title, description;


    private void Awake()
    {
        itemDescription.ResetDescription(); //poner que la descripcion se resetee al abrir y cerrrar el inventario
    }
    public void InitializeInventoryUI(int inventorysize)
    {
        //recorre todos los elementos de la lista
        for (int i = 0; i < inventorysize; i++)
        {
            InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            inventoryItems.Add(uiItem);
        }
    }

    private void Update()
    {
        if (inventory.instance.Inventory.activeInHierarchy)
        {
            itemDescription.ResetDescription();
        }
    }
    /*si el inventario esta abierto
    inventoryItems[0].SetData(image);

    si el objeto esta seleccionado
    itemDescription.SetDescription(image, title, description)
    */

}
