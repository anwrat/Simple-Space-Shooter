using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyprojectile;
    public float spawntimer;
    public float maxspawntimer;
    public float minspawntimer;
    // Start is called before the first frame update
    void Start()
    {
        spawntimer = Random.Range(minspawntimer,maxspawntimer);
    }

    // Update is called once per frame
    void Update()
    {
        spawntimer -= Time.deltaTime;
        if (spawntimer <= 0)
        {
            Instantiate(enemyprojectile,transform.position,Quaternion.identity);
            spawntimer = Random.Range(minspawntimer, maxspawntimer);
        }
    }
}
