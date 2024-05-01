using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    //tiempo de vida para destruir el objeto
    public float lifeTime;

  
    void Start()
    {
        //destruir el objeto pasado un tiempo dado
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    
}
