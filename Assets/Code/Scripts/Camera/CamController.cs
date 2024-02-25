using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CamController : MonoBehaviour
{

    public Transform target; //pos. del objetivo de la c�mara
    public float minHeight, maxHeight; //pos. m�xima y m�nima
    public Transform farBackground, middleBackground; //pos. fondos
    private Vector2 _lastPos;

  
    void Start()
    {
        //Al empezar el juego se guardar� la �ltima posici�n del jugadoor
        _lastPos = transform.position;
    }

    // Para evitar problemas de tirones de la c�mara, LateUpdate. Se llama tambi�n una vez por frame pero despu�s de los Updates.
    void LateUpdate()
    {
        ////La c�mara sigue al jugador sin variar su posici�n en Z
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        ////Creamos una restricci�n entre un m�nimo y un m�ximo para el movimiento de la c�mara en Y
        //float _clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        ////Actualizamos el movimiento de la c�mara usando las restricciones
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

        //El fondo de las nubes se va a mover sin embargo a la mita de velocidad que lleve el jugador, luego se mover� la mitad
        //middleBackground.position += new Vector3(_amountToMoveX * .5f, 0f, 0f);
        middleBackground.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .5f;


        //Actualizar pos. del jugador
        _lastPos = transform.position;
    }
}
