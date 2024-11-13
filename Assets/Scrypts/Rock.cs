using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private bool isSpecialRock;
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
            if (!isSpecialRock)
            {
                GameManager.Instance.DecreaseLive(1);
                Destroy(gameObject);
            }
            else
            {
                GameManager.Instance.DecreaseLive(2);
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.tag == "Destroy")
        {
            
            Destroy(gameObject);
        }
    }
}
