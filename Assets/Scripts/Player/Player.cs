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
    [SerializeField] private GameObject packageSlot;
    private bool isStunned;
    public bool hasPackage;
    private Rigidbody2D rb2D;
    private bool isFacingRight;
    [SerializeField] private float attackAnimationTime;
    private bool isAttacking;
    public bool isInteracting;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isAttacking = false;
        isStunned = false;
        hasPackage = false;
    }

    void Update()
    {
        if (packageSlot != null)
        {
            hasPackage = true;
        }
        FlipCharacter();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void SetPackage(GameObject package)
    {

        packageSlot = package;
        package.transform.SetParent(this.transform);
        package.transform.localPosition = Vector3.zero;
        hasPackage = true;
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
        if (!isAttacking && !hasPackage)
        {
            StartCoroutine(Attack());
        }
    }

    void OnInteract(InputValue value)
    {

        if (packageSlot != null)
        {
            DropPackage();
        }
        else  if (!isInteracting)
        {
            StartCoroutine(Interact());
        }




    }

    private void DropPackage()
    {
        packageSlot.transform.parent = null;
        packageSlot.transform.position = transform.position + Vector3.down;
        packageSlot = null;
        hasPackage = false;
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

    } IEnumerator Interact()
    {
        isInteracting = true;
        yield return new WaitForSeconds(attackAnimationTime);
        isInteracting = false;
        yield break;

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Package") && !hasPackage && isInteracting)
        {
            SetPackage(collider.transform.gameObject);
        }
    }

}
