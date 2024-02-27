using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    //si el jugador se mete dentro de un trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Tevacae");
            //método que hace daño
            collision.GetComponent<PlayerHealthController>().DealWithDamage();
        }

    }
}
