using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string scenetoload;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(scenetoload);
    }
}
