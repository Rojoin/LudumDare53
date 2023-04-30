using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Building : MonoBehaviour
{
    public static int count = 0;
    public int index = 0;
    public bool active = false;
    public bool delivered = false;
    public TMP_Text buildingText;


    void Awake()
    {
        index = count;
        count++;
        buildingText.text = "";
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (delivered)
                {
                    buildingText.text = "Ya te entregamos el pedido, no te lo vamos a volver a entregar";
                }
                else
                {
                    buildingText.text = "Toma tu pedido :)";
                    delivered = true;
                    // other.GetComponent<Player>().hasPackage = true;
                }
            }
        }
    }
}