using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorGameOver : MonoBehaviour
{
    public RectTransform[] points;

    public int currentPoint;

    public RectTransform _cursorPosition;

    private GameOverMenu _gOverMenu;

    private void Awake()
    {
        _gOverMenu = GameObject.Find("LevelManager").GetComponent<GameOverMenu>();
    }
    void Start()
    {
        currentPoint = 0;
    }

    void Update()
    {

        _cursorPosition.position = points[currentPoint].position;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (currentPoint == 0) currentPoint = 1;
            else currentPoint--;


        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
        }

        if (currentPoint == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _gOverMenu.Continue();
        }

        if (currentPoint == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _gOverMenu.Menu();
        }


    }
}

