using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //This command makes a debug message appear in Unity so we know if the quit button is working
        Application.Quit(); ///Closes the game
    }
    public void LoadMainMenu()
    {
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
