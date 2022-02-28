/*
 *  GameSession
 *  handle the game session data 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Variables
    int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }

    // Game Session is a singleton, only 1 game session obj is allowed to exists
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() { return score; }

    public void AddToScore(int scoreValue) { score += scoreValue; }

    // reset the game by destroying the cur game session
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
