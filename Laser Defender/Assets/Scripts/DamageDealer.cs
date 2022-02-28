/*
 *  DamageDealer
 *  makes the obj that hold this class deal damage to other obj 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Config params
    [SerializeField] int damage = 100;

    public int GetDamage() { return damage; }

    // destroy the game obj when it hit something
    public void Hit()
    {
        Destroy(gameObject);
    }

}
