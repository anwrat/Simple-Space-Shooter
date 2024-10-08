using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)//Function that is executed when object collides with sth
    {
        if (collision.gameObject.tag == "Boundary")
        {
            //Subtracting y axis position of object every time they hit collider
            transform.position = new Vector3(transform.position.x,transform.position.y-1,transform.position.z);
            moveSpeed *= -1;//if the original movespeed is 5, it changes to -5 changing the move direction
        }
        if(collision.gameObject.tag == "LowerBoundary")
        {
            Destroy(gameObject);
        }
    }
}
