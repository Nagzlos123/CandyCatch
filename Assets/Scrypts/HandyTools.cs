using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandyTools 
{
    public static int RandomElement<T>(T[] elemets)
    {
        int randomNumber = Random.Range(0, elemets.Length);

        return randomNumber;
    }
}
