using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerObj;
    public GameObject WaterObj;
    public GameObject MainMenuUI;
    public GameObject CreditsUI;
    public GameObject ScoreUI;

	void Start ()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        PlayerObj.GetComponent<CheckGround>().enabled = false;
        WaterObj.GetComponent<LoseTrigger>().enabled = false;
        MainMenuUI.SetActive(true);
        ScoreUI.SetActive(false);
    }

    void Update()
    {
        if (!GameManager.isStarted && !GameManager.isDead && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.isStarted = true;
            OnStartPressed();
        }
        else if (GameManager.isStarted && GameManager.isDead && Input.GetKeyDown(KeyCode.Space))
        {
            OnRestartPressed();
        }
    }

    public void OnStartPressed()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        PlayerObj.GetComponent<CheckGround>().enabled = true;
        WaterObj.GetComponent<LoseTrigger>().enabled = true;
        MainMenuUI.SetActive(false);
        ScoreUI.SetActive(true);
    }

    public void OnCreditsPressed()
    {
        MainMenuUI.SetActive(false);
        CreditsUI.SetActive(true);
        ScoreUI.SetActive(false);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnBackPressed()
    {
        MainMenuUI.SetActive(true);
        CreditsUI.SetActive(false);
    }

    public void OnRestartPressed()
    {
        GameManager.isStarted = false;
        GameManager.isDead = false;
        GameManager.AmountOfScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
