using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    //refs
    public Animator animpuerta;
    private SpriteRenderer _sr;
    private LevelManager _lReference;
    private bool _canOpenDoor = false;
    private PlayerC _pCReference;
    public GameObject infoPanel;
   

    private void Awake()
    {
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        animpuerta = GetComponent<Animator>();
        _pCReference = GameObject.Find("Player").GetComponent<PlayerC>();

    }

    void Update()
    {

        //para que compruebe que si la puerta esta abierta
        if (Input.GetKeyDown(KeyCode.F) && _canOpenDoor == true)
        {
            animpuerta.SetTrigger("pliopen");
            _lReference.ExitLevel();
            _pCReference.interacting = true;
           
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canOpenDoor = true;
            infoPanel.SetActive(true);
        }
    }

    //hay que poner que cuando salga del trigger que sea falso
    private void OnTriggerExit2D(Collider2D collision)
    {
        _canOpenDoor = false;
        infoPanel.SetActive(false);
    }
}
