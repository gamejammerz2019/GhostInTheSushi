using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            TogglePauseMenu();
        }
    }

    // Update is called once per frame
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (gameObject.GetComponentInChildren<Canvas>().enabled)
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }
}