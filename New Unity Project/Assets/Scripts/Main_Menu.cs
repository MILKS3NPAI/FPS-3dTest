using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*Holds functions for a main menu
-Play
-Quit game
 */
public class Main_Menu : MonoBehaviour
{
    //Advances to next scene in index
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Closes application
    public void QuitGame()
    {
        Application.Quit();
    }
}
