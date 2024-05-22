using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImag;
    [SerializeField] private TMP_Text price;
    private bool empty = true;
}
