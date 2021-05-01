using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button_Manager : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("INGAME");
    }
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
