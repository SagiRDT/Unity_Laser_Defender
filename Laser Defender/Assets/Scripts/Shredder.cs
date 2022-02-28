/*
 *  Shredder
 *  The shredder will destroy every game obj that colllide with it
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    // Destroy the game obj that collide with the shredder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}
