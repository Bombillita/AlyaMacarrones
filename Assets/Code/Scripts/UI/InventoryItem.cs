using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImag;
    [SerializeField] private TMP_Text price;
    [SerializeField] Image borderImg;
    private bool empty = true;

    public event Action<InventoryItem> OnItemSelected;

    public void Awake()
    {
        ResetData();
        Deselect();

    }

    public void ResetData()
    {
        this.itemImag.gameObject.SetActive(false);
        empty = true;

    }

    public void Deselect()
    {
        borderImg.enabled = false;
    }

    public void SetData(Sprite sprite)
    {
        this.itemImag.gameObject.SetActive(true);
        this.itemImag.sprite = sprite;
        empty = false;
    }

    public void Select()
    {
        borderImg.enabled = true;
    }

    public void ItemSelected(BaseEventData data)
    {
        if (empty)
        {
            return;
        }
        if (/*itemselected)*/ )
        {
            //itemselected.Invoke(this);
        }
        else
        {
            //si esta seleccionado.Invoke(this);
        }


    }

}
