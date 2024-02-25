using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para trabajar con elementos de UI

public class UIController : MonoBehaviour
{
    //Refs a las imágenes de las refs
    public Image healthBar;
    //Referencias a los sprites que cambian al ganar/perder salud
    public Sprite heartFull, heartMid, heartLow, heartEmpty;

    //Refs al Script que controla la vida del jugador
    private PlayerHealthController _pHReference;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia al PlayerHealthController
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    //M�todo para actualizar la vida en la UI
    public void UpdateHealthDisplay()
    {
        //En este caso ser� mejor implementar un Switch ya que depende del valor de una misma variable
        //Si la vida del jugador fuera 3
        //if(_pHReference.currentHealth == 3)
        //{
        //    heart1.sprite = heartFull;
        //    heart2.sprite = heartFull;
        //    heart3.sprite = heartFull;
        //}

        //Dependiendo del valor de la vida actual del jugador
        switch (_pHReference.currentHealth)
        {
            //En el caso en el que la vida actual valga 3 - vida completa
            case 3:
                healthBar.sprite = heartFull; 
                //Cerramos el caso y salimos del Switch
                break;
            //En el caso en el que la vida actual valga 2 - falta 1 corazon
            case 2:
                healthBar.sprite = heartMid ;
    
                break;
            //En el caso en el que la vida actual valga 1 - faltan 2 corazones
            case 1:
                healthBar.sprite = heartLow;
                break;
            //En el caso en el que la vida actual valga 0 - no hay corazone
            case 0:
                healthBar.sprite = heartEmpty;
                break;
            //En el caso por defecto, el jugador estar� muerto - no hay corazones
            default:
                healthBar.sprite = heartEmpty;
                break;
        }

    }
}
