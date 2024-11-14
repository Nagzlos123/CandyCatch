using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void BestScore()
    {
        Debug.Log("Displaing best score!");
    }

    public void Quit()
    {
      HandyTools.QuitGame();
    }
}
