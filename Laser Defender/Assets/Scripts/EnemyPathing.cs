/*
 *  EnemyPathing
 *  makes the enemies move acordding to a list of waypoints 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // config params
    WaveConfig waveConfig;
    List<Transform> waypoints;

    // Variables
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // set the wave config to a new wave config we get as param
    public void SetWaveConfig(WaveConfig waveConfig) { this.waveConfig = waveConfig; }

    // handle the enemy moving to the next waypoint from our waypoints list
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            // make the enemy move to the waypoint
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            // if he got to the waypoint load the next waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
