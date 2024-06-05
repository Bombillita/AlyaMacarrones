using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] soundEffects;

    public AudioSource bgm;

    public static AudioManager audioMReference;

    // Start is called before the first frame update
    void Start()
    {
        if (audioMReference == null)
            audioMReference = this;
    }

    public void PlaySFX(int soundToPlay) //soundToPlay = sera el sonido número X del array que queremos reproducir
    {
        //Si ya estaba reproduciendo el sonido, lo paramos
        soundEffects[soundToPlay].Stop();
        //Alteramos un poco el sonido cada vez que se vaya a reproducir
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        //Reproducir el sonido pasado por parámetro
        soundEffects[soundToPlay].Play();
    }
}
