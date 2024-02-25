using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CamController : MonoBehaviour
{

    public Transform target; //pos. del objetivo de la cámara
    public float minHeight, maxHeight; //pos. máxima y mínima
    public Transform farBackground, middleBackground; //pos. fondos
    private Vector2 _lastPos;

  
    void Start()
    {
        //Al empezar el juego se guardará la última posición del jugadoor
        _lastPos = transform.position;
    }

    // Para evitar problemas de tirones de la cámara, LateUpdate. Se llama también una vez por frame pero después de los Updates.
    void LateUpdate()
    {
        ////La cámara sigue al jugador sin variar su posición en Z
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        ////Creamos una restricción entre un mínimo y un máximo para el movimiento de la cámara en Y
        //float _clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        ////Actualizamos el movimiento de la cámara usando las restricciones
        //transform.position = new Vector3(transform.position.x, _clampedY, transform.position.z);

        //equivalente:
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //conocer cuanto moverse solo en x
        // /float _amountToMoveX = transform.position.x - _lastXPos;
        //en x e y:
        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);

        // Como el fondo del cielo se mueve a la misma velocidad que el jugador, le decimos que se mueva lo mismo que este
        //farBackground.position = farBackground.position + new Vector3(_amountToMoveX, 0f, 0f);
        farBackground.position = farBackground.position + new Vector3(_amountToMove.x, _amountToMove.y, 0f);

        //El fondo de las nubes se va a mover sin embargo a la mita de velocidad que lleve el jugador, luego se moverá la mitad
        //middleBackground.position += new Vector3(_amountToMoveX * .5f, 0f, 0f);
        middleBackground.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .5f;


        //Actualizar pos. del jugador
        _lastPos = transform.position;
    }
}
