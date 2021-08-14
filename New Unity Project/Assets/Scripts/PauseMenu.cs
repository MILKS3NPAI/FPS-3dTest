using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Holds functions for a pause menu
-Resume
-Load Menu
-Quit game
 */
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;


    public  GameObject pauseMenuUI;

 

    //Resumes time in-game and hides pauseMenu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    //Pauses time in-game and shows pauseMenu
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Escape()
    {
        Debug.Log("Paused");
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    //Returns to main menu (ASSUMING MAIN MENU IS SCENE INDEX 0)
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    //Quits game
    public void QuitGame()
    {
        Application.Quit();
    }
}
