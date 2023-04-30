using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Building : MonoBehaviour
{
    public ZombieSpawn zombieSpawn;
    public static int count = 0;
    public int index = 0;
    public bool active = false;
    public bool delivered = false;
    public TMP_Text buildingText;
    private bool isPressed;
    public GameObject package;


    void Awake()
    {
        index = count;
        count++;
       // buildingText.text = "";
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (delivered)
            {
                buildingText.text = "Ya te entregamos el pedido, no te lo vamos a volver a entregar";
            }
            else
            {
                buildingText.text = "Toma tu pedido :)";
                delivered = true;
                zombieSpawn.SetZombieTarget(package);
                other.GetComponent<Player>().SetPackage(package);
            }
        }
    }
}