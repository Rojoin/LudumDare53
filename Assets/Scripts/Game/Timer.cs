using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    [SerializeField] private float maxTime;
    [SerializeField] private int menuIndex;

    private SelectScene selectScene;
    private float time;

    private void Start()
    {
        selectScene = new SelectScene();
        time = maxTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        timer.text = "" + time.ToString("f2");

        if(time < 0)
        {
            time = maxTime;
            selectScene.GoToScene(menuIndex);
        }
    }

}
