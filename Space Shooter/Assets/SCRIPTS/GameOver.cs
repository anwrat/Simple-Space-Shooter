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
            if (!isBlinking)
            {
                StartCoroutine(BlinkText());
                isBlinking = true;
            }
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
