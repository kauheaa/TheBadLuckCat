using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseP;
    [SerializeField]
    private GameObject deathP;
    [SerializeField]
    private GameObject winScreen;
    public static SceneSwitcher instance;
    private Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

       


    }
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("FirstLevel");
    }

//lisäsin how to play scenen ja linkin start menuun, tää on se. t vilma :-)
    public void OnHowToButtonPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnRestartButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstLevel");
    }
    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void OnPause()
    {
        pauseP.SetActive(!pauseP.activeSelf);


        Time.timeScale = 0f;

        if (!pauseP.activeSelf)
        {

            Time.timeScale = 1f;
        }
    }
    public void OnDeath()
    {

        animator = GetComponent<Animator>();
        deathP.SetActive(!deathP.activeSelf);

        Time.timeScale = 0f;

        if (!deathP.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
    public void WinScreen()
    {
        winScreen.SetActive(!winScreen.activeSelf);
        Time.timeScale = 0f;
    }
}