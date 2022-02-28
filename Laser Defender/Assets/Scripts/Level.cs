/*
 *  Level
 *  Handle scene loading (menu, levels, game over, etc..)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Config params
    [SerializeField] float delayInSeconds = 2f;

    // load the main menu
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // start the game
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        GameSession gameSession = FindObjectOfType<GameSession>();
        if(gameSession) gameSession.ResetGame();
    }

    // load game over
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    // wait a few secs before loading the game over screen
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
    
    // quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

}
