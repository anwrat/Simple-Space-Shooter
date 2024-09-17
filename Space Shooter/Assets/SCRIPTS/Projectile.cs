using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);//Destroy projectile after collision
        }
        //Destroy projectile at the top of screen if it misses enemies
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
