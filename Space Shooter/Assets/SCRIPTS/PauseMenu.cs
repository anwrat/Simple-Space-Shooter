using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausepanel;
    public AudioSource bgm;
    public string menuscenename;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                bgm.Play();
                ContinueGame();
            }
            else { 
                bgm.Pause();
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;//Pauses the game's time
        pausepanel.SetActive(true);
        isPaused = true;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1; //Resume the game
        pausepanel.SetActive(false);
        isPaused = false;
    }

    public void ExittoMenu()//Function to load scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuscenename);
    }
}
