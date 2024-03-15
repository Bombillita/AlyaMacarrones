using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    //Referencias
    public Image fadeScreen; //referencia al fade screen
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack; //cuando hacemos el fundido a negro o vuelta a transparente

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si hay que hacer fundido a negro
        if (shouldFadeToBlack)
        {
            //cambiarlatransparencia del color a opaco
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //MathfMovetowards -> valor que queremos cambiar, valor al que lo queremos cambiar y velocidad)
            //si el color es opaco
            if (fadeScreen.color.a == 1f)
            {
                //paramos el fundido a negro
                shouldFadeToBlack = false;
            }
        }

        //Si hay que hacer fundido transparente
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }


        }
    }

    //Método para el fundido a negro
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    //Metodo para el fundido transparente
    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
