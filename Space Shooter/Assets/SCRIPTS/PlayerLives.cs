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
    public GameOver gameover;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionprefab, transform.position, Quaternion.identity);
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
            pointmanager.HighScoreUpdate();
            gameoverpanel.SetActive(true);
            gameover.Gameisover();
        }
    }
}
