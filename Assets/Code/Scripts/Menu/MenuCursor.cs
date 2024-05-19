using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCursor : MonoBehaviour
{
    public RectTransform[] points;

    public int currentPoint;

    public RectTransform _cursorPosition;

    private PauseMenu _pMenuRef;

    private void Awake()
    {
        _pMenuRef = GameObject.Find("LevelManager").GetComponent<PauseMenu>();
    }
    void Start()
    {
        currentPoint = 0;
    }

    void Update()
    {

        _cursorPosition.position = points[currentPoint].position;
        //_cursorPosition.position = new Vector2(Input.GetAxis("Vertical")

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (currentPoint == 0) currentPoint = 3;
            else currentPoint--;


        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (currentPoint == points.Length - 1) currentPoint = 0;
            else currentPoint++;
        }

        if (currentPoint == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            _pMenuRef.Reanudar();
        }

        if (currentPoint == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            _pMenuRef.Objetos();
        }

        if(currentPoint == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Galeria");
        }

        if (currentPoint == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
