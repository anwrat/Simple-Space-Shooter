using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(transform.position.x, transform.position.y,180); // Make the top of projectile face down at start
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime);//Vector2.up even if the projectile goes down because the projectile is rotated by 180 degrees at start
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Boundary" || collision.gameObject.tag == "LowerBoundary")
        {
            Destroy(gameObject);
        }
    }
}
