using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HandyTools 
{
    public static int RandomElement<T>(T[] elemets)
    {
        int randomNumber = Random.Range(0, elemets.Length);

        return randomNumber;
    }


    public static void QuitGame()
    {
        Debug.Log("Aplication: Game Over!");
        Application.Quit();
    }
}
