using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public static int count = 0;
    public int index = 0;
    public bool active = false;

    void Awake()
    {
        index = count;
        count++;
        Debug.Log("index: " +  index);
    }

    


}
