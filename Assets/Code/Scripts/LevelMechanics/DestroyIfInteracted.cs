using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyIfInteracted : MonoBehaviour
{
    public bool ischeckpoint;
    public bool isnpc;

    private Checkpoint _cpRef;
    [SerializeField] GameObject Triggerobj;
    public bool isDestroying = false;
    [SerializeField] GameObject SpawnableObj;
    
    


    void Start()
    {
        _cpRef = GameObject.Find("Checkpoint").GetComponent<Checkpoint>();  
    }

    void Update()
    {
        if (_cpRef.cpActive == true)
        {
            Triggerobj.SetActive(true);
        }

        if (TriggerObject.triggerOn == true && Input.GetKeyDown(KeyCode.E))
        {
            isDestroying = true;
        }
        else
        {
            isDestroying = false;
        }

        if (TriggerObject._destroyed == true)
        {
            Triggerobj.SetActive(false);
            SpawnableObj.SetActive(true);
        }
        
    }




}
