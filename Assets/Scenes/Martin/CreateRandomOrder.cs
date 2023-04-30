using UnityEngine;
using System.Collections.Generic;

public class CreateRandomOrder : MonoBehaviour
{
    public List<Building> buildingsList = new List<Building>();

    public List<House> houseList = new List<House>();

    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {

    }



    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        getOrder();
    //    }
    //}

    //string RandomBuildings()
    //{
    //    string building = BuildingsList[randomNumber];

    //    BuildingsList.Remove(building);

    //    return building;

    //}

    //string RandomOrders()
    //{
    //    string Order = buildingsList[randomNumber];

    //   buildingsList.Remove(Order);

    //    return Order;
    //}

    //void getOrder()
    //{
    //    if (buildingsList.Count > 0)
    //    {
    //        Debug.Log("Tienes que buscar: " + RandomOrders());
    //        Debug.Log("En: " + RandomBuildings());
    //    }
    //    else
    //    {
    //        Debug.Log("No tienes mas ordenes");
    //    }
    //}
}