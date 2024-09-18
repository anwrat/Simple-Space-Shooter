using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausepanel;
    // Start is called before the first frame update
    void Start()
    {
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else { 
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
}
