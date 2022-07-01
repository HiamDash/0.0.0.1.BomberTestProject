using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void Scenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes); 
        Time.timeScale= 1f;
    }
     
    public void Exit()
    {
        Application.Quit();
    }
}