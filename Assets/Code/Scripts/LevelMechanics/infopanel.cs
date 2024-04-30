using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infopanel : MonoBehaviour
{
    public GameObject info;
    private PlayerC _pCRefernce;

    // Start is called before the first frame update
    void Start()
    {
        _pCRefernce = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            info.SetActive(true);
            collision.GetComponent<PlayerC>().canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            info.SetActive(false);
            collision.GetComponent<PlayerC>().canInteract = false;
        }
    }

    public void Update()
    {
        if (_pCRefernce.interacting == true)
        {
            info.SetActive(false);
        }
    }
}
