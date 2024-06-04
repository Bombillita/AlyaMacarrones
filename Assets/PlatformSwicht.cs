using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSwicht : MonoBehaviour
{
    [SerializeField] EdgeCollider2D Plataforma;
    [SerializeField] SpriteRenderer SpritePlataforma;

    public bool desactivar = false;



    // Update is called once per frame
    void Update()
    {

        if (desactivar == true)
        {
            StartCoroutine(Desaparecer());
        }

    }
    private void OnCollisionEnter2D(Collision2D coll)
    {



        if (coll.gameObject.tag == "Player" && desactivar == false)
        {
            StartCoroutine(Mantener());
        }
        else desactivar = false;

    }
    private IEnumerator Mantener()
    {
        yield return new WaitForSeconds(0.5f);
        desactivar = true;

    }
    private IEnumerator Desaparecer()
    {
        Plataforma.enabled = false;
        SpritePlataforma.enabled = false;
        yield return new WaitForSeconds(5f);
        desactivar = false;
        Plataforma.enabled = true;
        SpritePlataforma.enabled = true;
    }
}