using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TittleScreenControler : MonoBehaviour
{
    public void _PlayButton(){
        SceneManager.LoadScene("GamePlayScene");
    }

    public void _ExitButton(){
        Application.Quit();
    }
}
