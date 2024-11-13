using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            GameManager.Instance.InremetScore();
            GameManager.Instance.UpdateLevelObjective();
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Destroy")
        {
            GameManager.Instance.DecreaseLive();
            Destroy(gameObject);
        }
    }
}
