using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate;
    private float timer;
    // public float leftWidth;
    // public float rightWidth;
    // public float topHeight;
    // public float bottomHeight;
    public float heightOffset;
    public float widthOffset;
    public float initialHeight;
    public float initialWidth;
    // Start is called before the first frame update
    void Start()
    {
        this.spawnRate = 2f;
        this.timer = 0;
        this.heightOffset = 5.0f;
        this.widthOffset = 5.0f;
        initialHeight = transform.position.y;
        initialWidth = transform.position.x;
        // this.leftWidth = 25.0f;
        // this.rightWidth = 30.0f;
        // this.topHeight = 9.0f;
        // this.bottomHeight = -2.0f;
        // this.birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        // this.heightOffset = 5;
        spawnClouds();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else{
            if (BirdScript.birdIsAlive){
                spawnClouds();
            }
            timer = 0;
        }
    }

    void spawnClouds(){
        float lowestPoint = initialHeight - heightOffset;
        float highestPoint = initialHeight + heightOffset;
        float mostLeftPoint = initialWidth - widthOffset;
        float mostRightPoint = initialWidth + widthOffset;
        Instantiate(cloud, new Vector3(Random.Range(transform.position.x, transform.position.x + widthOffset), Random.Range(transform.position.y, transform.position.y + heightOffset), 0), transform.rotation);
    }
}
