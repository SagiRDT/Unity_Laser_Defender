/*
 *  MusicPlayer
 *  The obj tht plays the game background music
 *  A singletone obj, theres only 1 music player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    
    void Awake()
    {
        SetUpSingleton();
    }

    // music player is a singleton obj, only 1 allowed
    private void SetUpSingleton()
    {

        if ( FindObjectsOfType(GetType()).Length > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
