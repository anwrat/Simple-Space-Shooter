using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hinput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //This gives three values either 0,1 or -1. 0 is for no input, 1 is for right, -1 os for left
        hinput = Input.GetAxisRaw("Horizontal");
        //Vector2 gives (x,y) coordinates, Vector2.right means (1,0) i.e it moves to right
        transform.Translate(Vector2.right *hinput* moveSpeed*Time.deltaTime);
    }
}
