using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloudScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float cloudSpeed;
    public float deadZone;
    // public float cloudSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(SpawnClouds());
        this.cloudSpeed = 5.0f;
        this.deadZone = -45.0f;
    }

    // IEnumerator SpawnClouds()
    // {
    //     while (true)
    //     {
    //         // Spawn a cloud at a random y position on the right side of the screen
    //         Vector3 spawnPosition = new Vector3(Random.Range(Screen.width*0.7f, Screen.width), Random.Range(Screen.height*0.3f, Screen.height*0.7f), 0);
    //         // spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
    //         // spawnPosition.z = 0;
    //         Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);

    //         yield return new WaitForSeconds(cloudSpawnRate);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        // foreach (Transform cloud in transform)
        // {
        //     cloud.position += Vector3.left * cloudSpeed * Time.deltaTime;

        //     // Destroy clouds that have gone off screen
        //     if (cloud.position.x < -Screen.width / 4)
        //     {
        //         Destroy(cloud.gameObject);
        //     }
        // }
        if (BirdScript.birdIsAlive){
            transform.position = transform.position + (Vector3.left * cloudSpeed) * Time.deltaTime;
        }

        if(transform.position.x < deadZone){
            Debug.Log("Clouds Deleted");
            Destroy(gameObject);
        }
    }
}
