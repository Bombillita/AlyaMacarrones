using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public bool isActive = false;

    public void ActivateObject()
    {
        GetComponent<Animator>().SetTrigger("Activate");
    }

    public void DeactivateObject()
    {
        GetComponent<Animator>().SetTrigger("Deactivate");
    }

}
