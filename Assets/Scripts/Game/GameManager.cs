using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public struct DeliveryOrder
    {
        public int house;
        public int building;
    }
    
    [SerializeField] private GameObject bagPrefab = null;
    [SerializeField] private Transform houses = null;
    [SerializeField] private Transform buildings = null;

    private static House[] houseList;
    private static Building[] buildingList;

    private DeliveryOrder actualOrder;
    private DeliveryOrder nextOrder;

    private Bag bag;
    private int score = 0;

    public static Action<int,string,string> OnBagRespawn;

    private void Awake()
    {
        houseList = houses.GetComponentsInChildren<House>();
        foreach (House h in houseList)
        {
            Debug.Log("House " + h.name + " is index " + h.index);
        }
        buildingList = buildings.GetComponentsInChildren<Building>();
        nextOrder = CreateDeliveryRequest();
        Bag.OnArrive += SwapDeliveryOrders;
    }

    private void OnDestroy()
    {
        Bag.OnArrive -= SwapDeliveryOrders;
    }

    private void Start()
    {
        score = 0;
        SwapDeliveryOrders(score);
    }

    private void SwapDeliveryOrders(int score)
    {
        actualOrder = nextOrder;
        buildingList[actualOrder.building].active = true;
        houseList[actualOrder.house].active = true;
        Bag.Attach(buildingList[actualOrder.building].transform);
        Bag.Instance.SetDeliveryOrder(actualOrder);
        nextOrder = CreateDeliveryRequest();
    }

    private DeliveryOrder CreateDeliveryRequest()
    {
        DeliveryOrder delorder;
        delorder.house = UnityEngine.Random.Range(0, houseList.Length);
        delorder.building = UnityEngine.Random.Range(0, buildingList.Length);
        Debug.Log("Deliver Order> From: Building " + delorder.building + " - To: House " + delorder.house);
        return delorder;
    }




}
