using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
   
    //public bool boolEjemplo = false;
    private LevelManager _lMRef;
 

    private void Awake()
    {
        _lMRef = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SaveGame()
    {
        _lMRef.SaveCurency();

    }

    public void LoadGame()
    {
        _lMRef.LoadCurerncy();

  
        /*if (PlayerPrefs.HasKey("boolEjemploGuardado"))
        {
            if (PlayerPrefs.GetInt("boolEjemploGuardado") == 1)
                boolEjemplo = true;
            else if (PlayerPrefs.GetInt("boolEjemploGuardado") == 0)
                boolEjemplo = false;
        } */
    } 
}
