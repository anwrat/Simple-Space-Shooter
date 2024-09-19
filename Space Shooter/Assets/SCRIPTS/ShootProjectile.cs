using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectileprefab;
    private bool readytoshoot = true; //Boolean value to check projectile cooldown
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is paused before firing
        if (Time.timeScale == 0) return;
        //Under Unity Edit, inside project setting we can change default buttons through input manager
        if (readytoshoot && Input.GetButtonDown("Fire1")) { //If projectile is not under cooldown time(Coroutine)
            //Spawn the projectile at the position of the object script is attached to
            readytoshoot = false;//set cooldown for projectile 
            StartCoroutine(waitbetweenshots());
            Instantiate(projectileprefab,transform.position,Quaternion.identity);//Quaternion.identity means no rotation
        }
    }
    //Coroutine function to wait for cetain seconds before being able to shoot again
    IEnumerator waitbetweenshots()
    {
        yield return new WaitForSeconds(1);
        readytoshoot=true;
    }
}
