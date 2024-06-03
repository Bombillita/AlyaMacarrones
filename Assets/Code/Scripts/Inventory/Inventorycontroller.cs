using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Inventorycontroller : MonoBehaviour
{

    public RectTransform[] points;
    public int currentPoint;
    public RectTransform cursorPosition;
    public bool itemselected = false;
    public static Inventorycontroller instance;

    void Start()
    {
        currentPoint = 0;
        //UpdateSelection();
    }

    void Update()
    {

        cursorPosition.position = points[currentPoint].position;


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (currentPoint == 0) currentPoint = currentPoint++;
            else currentPoint--;


        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
        }

      /*  if (Inventorycontroller.instance.itemselected == true)
        {
            UpdateSelection();
        } */
    }



    // private void UpdateSelection()
    // {
    //  for (int i = 0; i < points.Length; i++)
    //{
    //activa sprite renderer en el objeto seleccionado
    //  SpriteRenderer sr = points[i].GetComponent<SpriteRenderer>();
    // if (sr != null)
    //{
    //if (i == currentPoint)
    // {
    //     sr.enabled = true;
    //    itemselected = true;
    // }
    //   else
    //  {
    //       sr.enabled = false;
    //itemselected = false;
             //   }
           // }



}
    

