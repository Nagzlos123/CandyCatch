using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            GameManager.Instance.IncreaseLive();
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Destroy")
        {

            Destroy(gameObject);
        }
    }
}
