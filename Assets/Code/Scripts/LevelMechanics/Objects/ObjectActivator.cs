using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectActivator : MonoBehaviour
{
    public bool isActive = false;
    public Sprite offSprite, onSprite;
    private SpriteRenderer _sR;

    [SerializeField] private GameObject objeto1;
    [SerializeField] private GameObject objeto2;
    public Transform point;

    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
    }
    public void ActivateObject()
    {
        GetComponent<Animator>().SetTrigger("Activate");
        _sR.sprite = offSprite;
        Destroy(objeto1);
        Thread.Sleep(1000);
        Instantiate(objeto1, point.position, Quaternion.identity);
    }

    public void DeactivateObject()
    {
        GetComponent<Animator>().SetTrigger("Deactivate");
        _sR.sprite = onSprite;
    }


}
