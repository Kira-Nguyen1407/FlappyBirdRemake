using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int currentHighScore;
    public Text textScore;
    public Text finalScoreText;
    public Text displayhighScoreText;
    public Text gameOverHighScoreText;
    public GameObject gameOverScreen;
    public BirdScript birdScript;
    // public AudioClip getScore;
    // public AudioClip gameOverSound;

    [ContextMenu("Increase Score")]
    public void addScore(){
        playerScore = playerScore + 1;
        textScore.text = playerScore.ToString();
        
        // AudioSource.PlayClipAtPoint(getScore, transform.position);
    }

    void Start()
    {
        this.birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        // this.highScoreInt = 0;
    }

    public void ShowHighScore(){
        if(_TrySetNewHighScore(playerScore)){
            displayhighScoreText.text = "High Score: " + playerScore.ToString();
        }
        else{
            displayhighScoreText.text = "High Score: " + _GetHighScore().ToString();
        }
    }

    public int _GetHighScore(){
        return PlayerPrefs.GetInt("HighScore");
    }

    public bool _TrySetNewHighScore(int score){
        currentHighScore = _GetHighScore();
        if(score > currentHighScore){
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }

    public void restartGame(){
        SceneManager.LoadScene("TittleScene");
        Time.timeScale = 1;
        birdScript.resetBirdPosition();
        // birdScript.refreshBird();

        // BirdScript.birdIsAlive = true;
    }

    public void gameOver(){
        // AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        // GetComponent<AudioSource>().PlayOneShot(gameOverSound);
        BirdScript.birdIsAlive = false;
        finalScoreText.text = textScore.text;
        gameOverHighScoreText.text = displayhighScoreText.text;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }





    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

}
