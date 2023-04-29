using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private GameObject currentEnemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float distance;
    private bool isActive;
    [SerializeField] private float maxEnemyDistance;
    private bool inRange;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRangeToChase())
        {
            transform.position = Vector2.MoveTowards(transform.position, currentEnemy.transform.position,
                Time.deltaTime * speed);
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
}
