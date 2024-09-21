using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainship;
    public GameObject sideship;
    private float moveSpeed = 1; // Speed of the movement
    private float amplitude = 2; // How far up and down the ship will move
    public TMP_Text blinktext;
    private float blinktime = 0.5f;

    private Vector3 startPosition; // Starting position of the mainship

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the mainship
        startPosition = sideship.transform.position;

        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the mainship
        mainship.transform.Rotate(0, 0, 50 * Time.deltaTime);

        // Move the mainship up and down using sine wave
        float newY = Mathf.Sin(Time.time * moveSpeed) * amplitude;
        sideship.transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    IEnumerator BlinkText()
    {
        while (true) { 
            blinktext.enabled = !blinktext.enabled; // Toggle the visibility
            yield return new WaitForSeconds(blinktime); // Wait for the blink interval
        }
    }
}
