using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private bool canMove = true;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxPos;
    Rigidbody2D rigidbody2D;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        rigidbody2D.MovePosition(rigidbody2D.position + direction * moveSpeed * Time.fixedDeltaTime);

        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
