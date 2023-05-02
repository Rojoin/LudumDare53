using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer = default;

    [SerializeField] private float maxTime = default;
    [SerializeField] private int menuIndex = default;
    [SerializeField] private CanvasGroup GameOverScene = default;
    [SerializeField] private CanvasGroup PauseMenu = default;
    [SerializeField] private GameObject InGameUi = default;
    [SerializeField] private AudioSource musicSource = default;
    [SerializeField] private AudioClip gameplayMusicClip = default;
    [SerializeField] private AudioClip gameOverMusicClip = default;
    private AudioClip previousClip = default;
    private bool pause = false;
    public static bool canPlayerUpdate = true;
    public static bool GameOver = false;
    private float time = default;

    private void Start()
    {
        //musicSource = SoundManager.Instance.GetMusicSource();
        //musicSource.clip = gameplayMusicClip;
        time = maxTime;
        //DeactivateCanvasGroup(GameOverScene, false);
        //DeactivateCanvasGroup(PauseMenu, false);
        Time.timeScale = 1;
        pause = false;
        canPlayerUpdate = true;
        GameOver = false;
    }

    private void DeactivateCanvasGroup(CanvasGroup cG, bool state)
    {
        cG.alpha = state ? 1 : 0;
        cG.interactable = state;
        cG.blocksRaycasts = state;
    }

    private void Update()
    {
        if (!pause)
        {
            //time -= Time.deltaTime;
            int seconds = ((int)time % 60);
            int minutes = ((int)time / 60);
            //timer.text = $"{minutes:00}:{seconds:00}";

            if (time < 0)
            {
                //DeactivateCanvasGroup(GameOverScene, true);
                //DeactivateCanvasGroup(PauseMenu, false);

                //InGameUi.SetActive(false);
                pause = false;
                GameOver = true;
                canPlayerUpdate = false;
                Time.timeScale = 1;
            }
            canPlayerUpdate = true;
            Time.timeScale = 1;
        }
        else
        {
            canPlayerUpdate = false;
            Time.timeScale = 0;
        }

        if (!GameOver)
        {
            //DeactivateCanvasGroup(PauseMenu, pause);
            //InGameUi.SetActive(!pause);
        }

        //MusicController();
    }
    private void MusicController()
    {
        musicSource.clip = GameOver ? gameOverMusicClip : gameplayMusicClip;
        if (previousClip != musicSource.clip)
        {
            musicSource.Play();
        }

        previousClip = musicSource.clip;
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
