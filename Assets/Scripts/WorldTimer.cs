using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 10f;

    [SerializeField] TMPro.TextMeshProUGUI WorldTimeText;
    [SerializeField] string time;

    void Start()
    {
        currentTime = startingTime;
    }

    
    void Update()
    {
        Timer();
    }
    void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        WorldTimeText.text = time + currentTime.ToString ("0");

        if (currentTime < 0)
        {
            currentTime = 0;
        }

    }
}
