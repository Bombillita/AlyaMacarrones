using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    private SpriteRenderer _sR;
    private bool lookingLeft;

    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();

        if (lookingLeft == true)
        {
            _sR.flipX = false;
        }
        else
        {
            _sR.flipX= true;
        }
    }

    // Update is called once per frame
  
}
