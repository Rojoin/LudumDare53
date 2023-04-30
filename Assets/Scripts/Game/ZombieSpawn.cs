using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ZombieSpawn : MonoBehaviour
{

    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    [Header("Variables to spawn")]
    [SerializeField] private Transform[] spawn;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cemetery;
    [SerializeField] private Zombie zombie;
    [SerializeField] private float timeRespawn;
    [SerializeField] private int maxZombies;

    private float toSpawn = 0;
    private int zombieCounter = 0;

    void Start()
    {
        maxX = spawn.Max(spawn => spawn.position.x);
        minX = spawn.Min(spawn => spawn.position.x);
        maxY = spawn.Max(spawn => spawn.position.y);
        minY = spawn.Min(spawn => spawn.position.y);
    }


    void Update()
    {
        toSpawn += Time.deltaTime;

        if(toSpawn >= timeRespawn && zombieCounter < maxZombies) 
        { 
            toSpawn = 0;

            SpawnZombie();
        }
    }


    private void SpawnZombie()
    {
        Vector2 randPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        zombie.SetTargets(player, cemetery);

        zombieCounter++;

        Instantiate(zombie, randPosition, Quaternion.identity);
    }

}
