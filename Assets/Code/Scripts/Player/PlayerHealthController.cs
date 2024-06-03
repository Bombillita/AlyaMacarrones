using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    
    public static int currentHealth;
    public int maxHealth;
    public float invincibleLength; 
    private float _invincibleCounter; 

    //Referencias
    private UIController _uIReference;
    private PlayerC _pCReference;
    private SpriteRenderer _sR;
    private LevelManager _lReference;
    public GameObject deathEffect;
    public bool playerDead = false;
    private GameOverMenu _gOMenu;

    // Start is called before the first frame update

    private void Awake()
    {
       _gOMenu = GameObject.Find("LevelManager").GetComponent<GameOverMenu>();
    }
    void Start()
    {
        //Inicializamos refs
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pCReference = GetComponent<PlayerC>();
        _sR = GetComponent<SpriteRenderer>();
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        //Comprueba si el contador de invincibilidad esta vacio
        if (_invincibleCounter > 0)
        {
            //Resta 1 cada segundo
            _invincibleCounter -= Time.deltaTime;

            //Si el contador 0
            if (_invincibleCounter <= 0)
                //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad a tope
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, 1f);
        }

    }

    //Metodo para daño
    public void DealWithDamage()
    {
        //Si ya no somos invencibles
        if (_invincibleCounter <= 0)
        {
            //Restamos 1 de la vida que tengamos
            currentHealth--; //_currentHealth -= 1 <=> _currentHealth = _currentHealth - 1 <=> _currentHealth--


            if (currentHealth <= 0)
            {
                //Vida 0 si se queda en negativo
                currentHealth = 0;
                _gOMenu.GameOver();
                playerDead = true;
                _pCReference.gameObject.SetActive(false);
                




                //audio manager, sonido de muerte

                //EFECTO DE MUERTE 
                GameObject instance = Instantiate(deathEffect, transform.position, transform.rotation); //inicia el efecto de muerte
                //donde mira
                  instance.GetComponent<PlayerDeathEffect>().seeLeft = GetComponent<PlayerC>().seeLeft;
                



            }
            //Si recibe daño pero no muere
            else
            {
                //Inicializamos el contador de invencibilidad
                _invincibleCounter = invincibleLength;
                //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad a la mitad
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, .5f);
                //Ref de knockback
                _pCReference.Knockback();
                playerDead = false;
            }

            //Actualiza la UI
            _uIReference.UpdateHealthDisplay();

        }

    }

    //MÉTODO PARA CURAR AL JUGADOR
    public void HealPlayer()
    {
        //curamos a vida máxima
        //currentHealth = maxhealth
        //+1 vida de jugador

        currentHealth++;

        //si la vida actual es mayor que la máxima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            _uIReference.UpdateHealthDisplay();
        }
    }



    public void SaveHealthG()
    {
        PlayerPrefs.SetInt("currenthealth", currentHealth);
    }

    public void LoadHealthG()
    {
        if (PlayerPrefs.HasKey("currenthealth"))
        {
            _uIReference.UpdateHealthDisplay();
            currentHealth = PlayerPrefs.GetInt("currenthealth");
        }
    }
}

