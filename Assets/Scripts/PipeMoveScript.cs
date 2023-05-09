using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;

    // Start is called before the first frame update
    void Start()
    {
        this.moveSpeed = 5.0f;
        this.deadZone = -45.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdScript.birdIsAlive){
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x < deadZone){
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
