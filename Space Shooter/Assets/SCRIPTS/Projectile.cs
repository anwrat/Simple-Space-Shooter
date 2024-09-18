using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosion;
    //private to not show in unity 
    private PointManager pointmanager; 
    // Start is called before the first frame update
    void Start()
    {
        pointmanager = GameObject.Find("PointManager").GetComponent<PointManager>();//To know where the PointManager Script is
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Start explosion animation
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(collision.gameObject);//Destroy the object projectile collides with
            pointmanager.UpdateScore(1);//Set score after destroying enemies
            Destroy(gameObject);//Destroy projectile after collision
        }
        //Destroy projectile at the top of screen if it misses enemies
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
