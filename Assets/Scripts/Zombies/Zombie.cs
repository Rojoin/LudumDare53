using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Zombie Variables")]

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bag;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject cemetery;

    [SerializeField] private float initialSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float addSpeed;
    [SerializeField] private float maxEnemyDistance;
    [SerializeField] private float maxDistanceToPick;

    [SerializeField]private bool hasABag = false;
    private float distance;
    private bool isActive;
    public int health;
    public bool hasBeenAttacked;
    private float timer;
    public float maxEnemyInvencibilty;

    void Start()
    {
        distance = 1000;
        rb = GetComponent<Rigidbody2D>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetTargetDistance();

        if (hasBeenAttacked)
        {
            timer += Time.deltaTime;
            if (timer > maxEnemyInvencibilty)
            {
                timer = 0.0f;
                hasBeenAttacked = false;
            }
        }

        if (!isAlive()) 
        { 
            Destroy(this);
        }

        if(hasABag)
        {
            target = cemetery;

            bag.transform.position = transform.position;
            GetTargetDistance();
            if (isInRangeToPick())
            {
                hasABag = false;
                Destroy(bag);
            }

            var aux = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * currentSpeed);
            rb.MovePosition(aux);
            currentSpeed = 10;
        }
        else
        {
            target = bag;

            if(isInRangeToPick())
            {
                hasABag = true;
            }

            if (isInRangeToChase())
            {
                var aux = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * currentSpeed);
                rb.MovePosition(aux);
                currentSpeed += addSpeed;
            }
            else
            {
                currentSpeed = initialSpeed;
            }
        }

    }

    public void SetTargets(GameObject bag, GameObject cemetery)
    {
        this.bag = bag;
        this.cemetery = cemetery;
    }

    public void SetActiveState(bool state = true)
    {
        isActive = state;
    }

    private void GetTargetDistance()
    {
        if (target != null)
            distance = Vector2.Distance(transform.position, target.transform.position);

    }

    private bool isInRangeToChase()
    {
        if (target != null)
        {
            return distance < maxEnemyDistance;
        }
        else
        {
            return false;
        }
    }

    private bool isInRangeToPick()
    {
        if (target != null)
        {
            return distance < maxDistanceToPick;
        }
        else
        {
            return false;
        }
    }

    public void LoseHealth(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    private bool isAlive()
    {
        return health > 0;
    }
    void OnDrawGizmos()
    {
       Gizmos.color = Color.black;
       Gizmos.DrawWireSphere(transform.position,maxEnemyDistance);
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position,maxDistanceToPick);
       Gizmos.DrawLine(transform.position,target.transform.position);
   
    }

}
