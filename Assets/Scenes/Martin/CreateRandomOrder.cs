using UnityEngine;
using System.Collections.Generic;

public class CreateRandomOrder : MonoBehaviour
{
    public List<string> DeliveryBuildingsList = new List<string>();

    public List<string> OrdersList = new List<string>();

    int randomNumber;


    // Start is called before the first frame update
    void Start()
    {

        DeliveryBuildingsList.Add("building1");
        DeliveryBuildingsList.Add("building2");
        DeliveryBuildingsList.Add("building3");
        OrdersList.Add("Order1");
        OrdersList.Add("Order2");
        OrdersList.Add("Order3");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            getOrder();
        }
    }


    string RandomBuildings()
    {
        string building = DeliveryBuildingsList[randomNumber];

        DeliveryBuildingsList.Remove(building);

        return building;

    }


    string RandomOrders()
    {
        string Order = OrdersList[randomNumber];

        DeliveryBuildingsList.Remove(Order);

        return Order;
    }

    void getOrder()
    {
        if (DeliveryBuildingsList.Count > 0)
        {
            Debug.Log("Tienes que buscar: " + RandomOrders());
            Debug.Log("En: " + RandomBuildings());
        }
        else
        {
            Debug.Log("No tienes mas ordenes");
        }
    }
}