using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public static bool birdIsAlive = true;
    public float bottomBoundary;
    public float topBoundary;
    private Vector3 startPosition;
    public AudioClip birdJump;
    public AudioClip gameOverSound;
    public AudioClip hitPipesSound;
    public bool isPassingPipes;
    public bool isColliding;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Bird";
        this.flapStrength = 8.0f;
        this.logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        this.bottomBoundary = -14.0f;
        this.topBoundary = 17.0f;
        // transform.position = new Vector3(0, 3, 0); // Set the initial position of the bird at (0,0,0)
        startPosition = transform.position;
        this.isColliding = false;
        this.isPassingPipes = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myRigidbody.velocity = Vector2.up * flapStrength;
            if(!isColliding && !isPassingPipes){
                // AudioSource.PlayClipAtPoint(birdJump, transform.position);
                GetComponent<AudioSource>().PlayOneShot(birdJump);
            }
        }
        logic.ShowHighScore();
        checkBoundary();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isColliding = true;
        // AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        GetComponent<AudioSource>().PlayOneShot(hitPipesSound);
        logic.gameOver();
        myRigidbody.gravityScale = 0;
    }
    public void checkBoundary(){
        if(transform.position.y < bottomBoundary || transform.position.y > topBoundary){
            // AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            GetComponent<AudioSource>().PlayOneShot(gameOverSound);
            logic.gameOver();
            // myRigidbody.gravityScale = 0;

        }

        // if(transform.position.y > topBoundary){
        //     logic.gameOver();
        //     // myRigidbody.gravityScale = 0;
        // }
    }

    // public void refreshBird(){
    //     // BirdScript.birdIsAlive = true;
    //     birdIsAlive = true;
    //     myRigidbody.gravityScale = 2;

    // }

    public void resetBirdPosition()
    {
        transform.position = startPosition;
        BirdScript.birdIsAlive = true;
    }
}
