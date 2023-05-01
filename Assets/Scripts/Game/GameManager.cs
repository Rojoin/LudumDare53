using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    [SerializeField] private float maxTime;
    [SerializeField] private int menuIndex;
    [SerializeField] private GameObject GameOverScene;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject InGameUi;
    private bool pause = false;
    private float time;

    private void Start()
    {
        time = maxTime;
        GameOverScene.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }

    private void Update()
    {
        if (!pause)
        {
            time -= Time.deltaTime;
            int seconds = ((int)time % 60);
            int minutes = ((int)time / 60);
            timer.text = $"{minutes:00}:{seconds:00}";

            if (time < 0)
            {
                GameOverScene.SetActive(true);
                PauseMenu.SetActive(false);
                InGameUi.SetActive(false);
                pause = false;
            }
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if (!GameOverScene.activeSelf)
        {
            PauseMenu.SetActive(pause);
            InGameUi.SetActive(!pause);
        }
    }

    public void OnPause()
    {
        pause = !pause;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Reset()
    {
        SceneManager.LoadScene(1);
    }

}
