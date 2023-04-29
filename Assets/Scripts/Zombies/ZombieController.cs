using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private List<ZombieController> zombies;
    [SerializeField] private int MaxZombies;
    private ZombieController zombiePrefab;

    void Start()
    {
        for (int i = 0; i < MaxZombies; i++)
        {
            zombies.Add(Instantiate(zombiePrefab));
        }

        foreach (var zombie in zombies)
        {
            zombie.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateZombies()
    {
      
    }
}
