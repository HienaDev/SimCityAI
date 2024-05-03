/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using UnityEngine;
using URandom = UnityEngine.Random;
using LibGameAI.FSMs;

// The script that controls an agent using an FSM
public class AIBehaviour : MonoBehaviour
{
    // Minimum distance to small enemy
    [SerializeField]
    private float minDistanceToSmallEnemy = 9f;

    // Minimum distance to big enemy
    [SerializeField]
    private float minDistanceToBigEnemy = 11f;

    // Maximum speed
    [SerializeField]
    private float maxSpeed = 5f;

    // References to enemies
    private GameObject smallEnemy, bigEnemy;

    // Get references to enemies
    private void Awake()
    {
        smallEnemy = GameObject.Find("SmallEnemy");
        bigEnemy = GameObject.Find("BigEnemy");
    }

    // Create the FSM
    private void Start()
    {
        // Create the states
        // HERE!

        // Add the transitions
        // HERE!

        // Instantiate the state machine
        // HERE!
    }

    // Request actions to the FSM and perform them
    private void Update()
    {
        // Get actions from state machine and invoke them
        // HERE!

        // Meanwhile we can test individual AI actions here, but we must REMOVE
        // them when the state machine is finally working
        ChaseSmallEnemy();
        //RunAway();
    }

    // Chase the small enemy
    private void ChaseSmallEnemy()
    {
        // Get normalized direction towards small enemy
        Vector3 direction =
            (smallEnemy.transform.position - transform.position).normalized;

        // Move towards small enemy
        transform.Translate(direction * maxSpeed * Time.deltaTime, Space.World);
    }

    // Runaway from the closest enemy
    private void RunAway()
    {
        // Get vector to small enemy
        Vector3 toSmall = transform.position - smallEnemy.transform.position;
        // Get vector to big enemy
        Vector3 toBig = transform.position - bigEnemy.transform.position;

        // Get vector to closest enemy
        Vector3 toClosest =
            toSmall.magnitude < toBig.magnitude ? toSmall : toBig;

        // Move in the oposite direction
        transform.Translate(toClosest.normalized * maxSpeed * Time.deltaTime);
    }
}
