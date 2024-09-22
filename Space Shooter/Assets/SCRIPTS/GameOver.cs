using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverpanel;
    public GameObject playership;
    public TMP_Text blinktext;
    private float blinktime = 0.5f;
    private bool isBlinking = false;
    public string menuscenename;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverpanel.activeSelf)
        {
            if (!isBlinking)
            {
                StartCoroutine(BlinkText());
                isBlinking = true;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExittoMenu()//Function to load scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuscenename);
    }

    // Coroutine to blink the text
    IEnumerator BlinkText()
    {
        while (gameoverpanel.activeSelf) // Blink only when game over panel is active
        {
            blinktext.enabled = !blinktext.enabled; // Toggle the visibility
            yield return new WaitForSeconds(blinktime); // Wait for the blink interval
        }
    }
}
