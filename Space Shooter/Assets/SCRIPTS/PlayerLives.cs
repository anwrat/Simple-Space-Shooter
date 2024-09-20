using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionprefab;
    public GameObject gameoverpanel;
    public PointManager pointmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameoverpanel.activeSelf && Input.GetButtonDown("Accept")) 
        {
            ReplayLevel(); // Restart the level when Space is pressed
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.collider because if we use only collision.gameObject it returns the entire parent object holding all ships
        //collision.collider looks at the collider rather than parent object
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionprefab,transform.position,Quaternion.identity);
            UpdateLives();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionprefab, transform.position, Quaternion.identity);
            UpdateLives();
        }
    }

    private void UpdateLives()
    {
        lives -= 1;
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = (i < lives);
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
            pointmanager.HighScoreUpdate();
            gameoverpanel.SetActive(true); // Show game over panel
            Time.timeScale = 0;//Pauses the game's time
        }
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1;
        gameoverpanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
