using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rb2D;
    private bool isFacingRight;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight && direction.x < 0f)
        {
            Flip();
        }
        else if (!isFacingRight && direction.x > 0f)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + direction * speed* Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    void OnAction()
    {

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var localScale = playerSprite.transform.localScale;
        localScale.x *= -1f;
        playerSprite.transform.localScale = localScale;
    }
}
