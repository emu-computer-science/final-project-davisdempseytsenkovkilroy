using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
