using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlyaMechanics : MonoBehaviour
{
    //planta genreacion
    [SerializeField] private GameObject PlantaAlya;
    public Sprite offSprite, onSprite;
    private PlayerC _pCRefernce;
    public GameObject infopanel;
    private bool AlyaBaston = false;

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
            PlantaAlya.SetActive(true);
            StartCoroutine(LockMovement());
        }
    }

    //Puede interactuar
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
            collision.GetComponent<PlayerC>().canInteract = false;
        }
    }

    public IEnumerator LockMovement()
    {
        _pCRefernce.enabled = false;

        yield return new WaitForSeconds(1f);

        _pCRefernce.enabled = true;
    }

}


