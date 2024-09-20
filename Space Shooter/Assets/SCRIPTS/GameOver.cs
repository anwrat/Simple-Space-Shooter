using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverpanel;
    public GameObject playership;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverpanel.activeSelf)
        {
            Debug.Log("Game over panel is active");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter key pressed");
                Time.timeScale = 1;
                ReplayLevel();
            }
        }
    }
    public void Gameisover()
    {
        Destroy(playership);
        Time.timeScale = 0;
        gameoverpanel.SetActive(true);
    }

    public void ReplayLevel()
    {
        Debug.Log("Reloading the scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
