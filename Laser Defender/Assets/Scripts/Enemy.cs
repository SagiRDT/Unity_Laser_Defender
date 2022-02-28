/*
 *  Enemy
 *  Handle the enemies functionality 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Config params
    [Header("Basic Params")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;

    [Header("Projectile")]
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile = null;
    [SerializeField] float projectileSpeed = 8f;
    [SerializeField] AudioClip laserSound = null;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.75f;

    [Header("Death")]
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;

    // Variables
    float shotCounter;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    // make the enemy shot every few intervals
    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    // if the enemy got hit by a damage dealer obj (for example - laser) proccess the hit, deal dmg to the enemy and destroy it if its life reaches 0 or lower
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    // proccess a hit to the enemy obj, deal dmg to the enemy and destroy it if its life reaches 0 or lower
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    // fire the laser - create the laser animation, make it "fly" and play the laser sound
    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, (projectileSpeed * -1));

        // the laser sound effect
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
    }

    // handle the dying of the enemy
    private void Die()
    {
        // add points to the score according to the enemy score value
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

        // destroy the enemy and play an explosion vfx
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);

        // the death sound effect
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

}
