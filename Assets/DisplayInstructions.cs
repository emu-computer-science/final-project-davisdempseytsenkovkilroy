using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayInstructions : MonoBehaviour
{
    public void Display()
    {
        SceneManager.LoadScene("Instructions");
    }
}
