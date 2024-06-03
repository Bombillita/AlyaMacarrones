using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePos : MonoBehaviour
{

    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        transform.position = new Vector3(PlayerPrefs.GetFloat(sceneName + "x"), PlayerPrefs.GetFloat(sceneName + "y"), PlayerPrefs.GetFloat(sceneName + "z")); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat(sceneName + "x", transform.position.x);
        PlayerPrefs.SetFloat(sceneName + "y", transform.position.y);
        PlayerPrefs.SetFloat (sceneName + "z", transform.position.z);
    }
}
