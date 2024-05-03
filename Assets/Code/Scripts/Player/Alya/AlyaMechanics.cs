using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlyaMechanics : MonoBehaviour
{
    //planta genreacion
    [SerializeField] private GameObject PlantaAlya;
    [SerializeField] private GameObject PlantaAlya2;
    public Sprite offSprite, onSprite;
    public GameObject objectToSwitch;
    private PlayerC _pCRefernce;
    public GameObject infopanel;
    private bool AlyaBaston = false;
    private SpriteRenderer _sR;
    public bool activePlant = false;
    private bool _isPlant = false;
   

    // Start is called before the first frame update
    void Start()
    {
        _pCRefernce = GameObject.Find("Player").GetComponent<PlayerC>();
        _sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _pCRefernce.canInteract && _isPlant == true)
        {
            if (activePlant == false)
            {
                //planta1
                PlantaAlya.SetActive(true);
                StartCoroutine(LockMovement());
                activePlant = true;

                //planta2
                PlantaAlya2.SetActive(false);
                
            }

            else 
            {
                //planta1
                PlantaAlya.SetActive(false);
                StartCoroutine(LockMovement());
                activePlant = false;

                //planta2
                PlantaAlya2.SetActive(true);
            }

            
            
        }
       
    }

    //Puede interactuar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(true);
            collision.GetComponent<PlayerC>().canInteract = true;
            _isPlant = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infopanel.SetActive(false);
            collision.GetComponent<PlayerC>().canInteract = false;
            _isPlant = false;
        }
    }

    public IEnumerator LockMovement()
    {
        _pCRefernce.enabled = false;

        yield return new WaitForSeconds(1f);

        if (activePlant == true)
        {
            _sR.sprite = onSprite;
        }
        else
        {
            _sR.sprite = offSprite;
        }

        _pCRefernce.enabled = true;
    }

   
}


