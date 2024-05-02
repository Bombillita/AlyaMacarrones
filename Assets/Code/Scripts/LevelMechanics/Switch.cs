using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //refs
    public GameObject objectToSwitch;
    public Sprite downsprite, upsprite;
    public GameObject infopanel;
    private SpriteRenderer _sR;
    private PlayerC _pCRefernce;
    private bool _isSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        _pCRefernce = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _pCRefernce.canInteract && _isSwitch == true)
        {
            //si el objeto está desactivado
            if (objectToSwitch.GetComponent<ObjectActivator>().isActive == false)
            {
                objectToSwitch.GetComponent<ObjectActivator>().ActivateObject();
                objectToSwitch.GetComponent<ObjectActivator>().isActive = true;
                _sR.sprite = upsprite;

            }
            else
            {
                objectToSwitch.GetComponent<ObjectActivator>().DeactivateObject();
                objectToSwitch.GetComponent<ObjectActivator>().isActive = false;
                _sR.sprite = downsprite;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(true);
            collision.GetComponent<PlayerC>().canInteract = true;
            _isSwitch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(false);
            collision.GetComponent<PlayerC>().canInteract = false;
            _isSwitch = false;
        }
    }
}
