using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject howToPlay;
    public GameObject credits;
    public GameObject endMenu;
    public AudioSource ambianceSound;
    public AudioSource italianSound;
    public Timer time;

    private bool isPaused = false;

    private void Start()
    {
        //isPaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        howToPlay.SetActive(false);
        credits.SetActive(false);
        endMenu.SetActive(false);

        time = GetComponent<Timer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        GameEnd();

    }

    public void StartGame()
    {
        //isPaused = false;
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        italianSound.volume = 0.2f;
        ambianceSound.Play();
    }



    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        italianSound.volume = .2f;
        ambianceSound.Stop();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        italianSound.volume = 0.1f;
        ambianceSound.Play();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(true);
        credits.SetActive(false);
        howToPlay.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        //isPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OpenOptions()
    {
        //isPaused = true;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void OpenHowToPlay()
    {
        //isPaused = true;
        optionsMenu.SetActive(false);
        howToPlay.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Oyundan çýktý");
    }

    public void StartNewDay()
    {
        SceneManager.LoadScene("Level1");
        mainMenu.SetActive(false);
        Debug.Log("çalýþtý");
    }

    public void GameEnd()
    {
        if (time.gameEnded)
        {
            endMenu.SetActive(true);
            mainMenu.SetActive(false);
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            howToPlay.SetActive(false);
            credits.SetActive(false);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
