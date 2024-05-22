using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryDescription : MonoBehaviour
{
    [SerializeField] private Image itemImag;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    private bool empty = true;

    private void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.itemImag.gameObject.SetActive(false);
        this.title.text = "";
        this.description.text = "";
    }

    public void SetDescription(Sprite sprite, string itemName, string itemDescription)
    {
        this.itemImag.gameObject.SetActive(true);
        this.itemImag.sprite = sprite;
        this.title.text = itemName;
        this.description.text = itemDescription;
    }
}

  