using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInfoScene : MonoBehaviour
{
    //refs
    public GameObject infopanel;
    public GameObject infoObject;
    private PlayerC _pCRefernce;

    // Start is called before the first frame update
    void Start()
    {
        _pCRefernce = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _pCRefernce.canInteract)
        {                
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                infopanel.SetActive(false);
                infoObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(true);
            collision.GetComponent<PlayerC>().canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(false);
            infoObject.SetActive(false);
            collision.GetComponent<PlayerC>().canInteract = false;
        }
    }
}
