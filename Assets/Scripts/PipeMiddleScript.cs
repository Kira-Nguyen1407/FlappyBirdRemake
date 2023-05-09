using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public AudioClip getScore;
    public BirdScript birdScript;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        this.birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(!birdScript.isColliding){
            birdScript.isPassingPipes = true;
            // AudioSource.PlayClipAtPoint(getScore, transform.position);
            GetComponent<AudioSource>().PlayOneShot(getScore);
        }
        birdScript.isPassingPipes = false;
        logic.addScore();
    }
}
