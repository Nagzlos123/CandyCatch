using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _moveSpeed;
    private float _endPosX;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCloudTransparency()
    {
        float alpha = Random.Range(0.5f, 1.0f);
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, alpha);
    }

    public void StartFloting(float moveSpeed, float endPosX)
    {
        _moveSpeed = moveSpeed;
        _endPosX = endPosX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed);

        if(transform.position.x > _endPosX)
        {
            Destroy(gameObject);
        }
    }
}
