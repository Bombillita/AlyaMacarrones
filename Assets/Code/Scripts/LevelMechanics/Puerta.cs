using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    //refs
    public Animator animpuerta;
    private LevelManager _lReference;
    public bool _canOpenDoor = false;
    private PlayerC _pCReference;
    public GameObject infoPanel;
    public int levelToLoad;
    public string areatransitionName;
   
   

    private void Awake()
    {
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        animpuerta = GetComponent<Animator>();
        _pCReference = GameObject.Find("Player").GetComponent<PlayerC>();

    }

    void Update()
    {

        //para que compruebe que si la puerta esta abierta
        if (Input.GetKeyDown(KeyCode.E) && _canOpenDoor == true)
        {
            animpuerta.SetTrigger("pliopen");
            _pCReference.areatransitionName = areatransitionName;
            LoadLevel(levelToLoad);
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

    public void LoadLevel(int n)
    {
        StartCoroutine(_lReference.ExitLevelCo(n));
    }
}
