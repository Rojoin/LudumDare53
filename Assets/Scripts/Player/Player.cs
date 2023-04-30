using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private bool isStunned;
    public bool hasPackage;
    private Rigidbody2D rb2D;
    private bool isFacingRight;
    [SerializeField] private float attackAnimationTime;
    private bool isAttacking;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isAttacking = false;
        isStunned = false;
        hasPackage = false;
    }

    void Update()
    {
        FlipCharacter();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void FlipCharacter()
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

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + direction * speed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    void OnAction()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attack());
        }

        switch (hasPackage)
        {
            case true:
                DropPackage();
                break;
            case false:
                TakePackage();
                break;
        }
    }

    private void TakePackage()
    {
        throw new System.NotImplementedException();
    }

    private void DropPackage()
    {
        throw new System.NotImplementedException();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var localScale = playerSprite.transform.localScale;
        var localScale2 = playerSprite.transform.localScale;
        localScale.x *= -1f;
        localScale2.x *= -1f;
        playerSprite.transform.localScale = localScale;
        attackHitbox.transform.localScale = localScale2;
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackAnimationTime);
        attackHitbox.SetActive(false);
        isAttacking = false;
        yield break;

    }

}
