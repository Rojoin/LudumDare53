using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BuildingController : MonoBehaviour
{
    public static Action OnFoodGrab;
    public TMP_Text DeliverText;
    public Canvas canvas;
    public bool playerHasFood = false;

    private void Start()
    {
        DeliverText.text = "Hello Cus...oh its you";
    }

    public void CloseBuildingUI()
    {
        canvas.enabled = false;
    }

    public void CheckFoodGrab()
    {
        if (playerHasFood)
        {
            DeliverText.text = "Dude whats your problem? you already have the food, get out of here";
        }
        else
        {
            DeliverText.text = "Here, take this order";
            playerHasFood = true;
            OnFoodGrab();
        }
    }
}
