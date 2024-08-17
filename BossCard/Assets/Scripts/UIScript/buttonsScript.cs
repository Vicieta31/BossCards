using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {

        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void OnClickChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
