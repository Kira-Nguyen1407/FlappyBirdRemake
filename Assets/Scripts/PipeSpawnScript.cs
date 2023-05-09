using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    private float timer;
    public float heightOffset;

    // public GameObject bird;

    // public BirdScript birdScript;
    // Start is called before the first frame update
    void Start()
    {
        this.spawnRate = 3;
        this.timer = 0;
        // this.birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        this.heightOffset = 5;
        spawnPipes();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else{
            if (BirdScript.birdIsAlive){
                spawnPipes();
            }
            timer = 0;
        }
    }

    void spawnPipes(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
