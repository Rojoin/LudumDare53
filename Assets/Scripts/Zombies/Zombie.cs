using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private GameObject currentEnemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float currentSpeed;
    private float distance;
    private bool isActive;
    [SerializeField] private float maxEnemyDistance;
    public int health;
    public bool hasBeenAttacked;
    private float timer;
    public float maxEnemyInvencibilty;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRangeToChase())
        {
            transform.position = Vector2.MoveTowards(transform.position, currentEnemy.transform.position,
                Time.deltaTime * currentSpeed);
            currentSpeed += 0.00002f;
        }
        else
        {
            currentSpeed = initialSpeed;
        }

        if (hasBeenAttacked)
        {
            timer += Time.deltaTime;
            if (timer > maxEnemyInvencibilty)
            {
                timer = 0.0f;
                hasBeenAttacked = false;
            }
        }
        GetEnemyDistance();
    }

    public void SetEnemy(GameObject enemy)
    {
        currentEnemy = enemy;
    }

    public void SetActiveState(bool state = true)
    {
        isActive = state;
    }

    private void GetEnemyDistance()
    {
        if (currentEnemy != null)
            distance = Vector2.Distance(transform.position, currentEnemy.transform.position);

    }

    private bool isInRangeToChase()
    {
        if (currentEnemy != null)
        {
            return distance < maxEnemyDistance;
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
   
    }

}
