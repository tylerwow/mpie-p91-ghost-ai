using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    enum GhostState {
        WANDER,
        CHASE,
        RETURN
    }

    GhostState state;

    public GameObject player;
    public GhostTrigger ghostTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        state = GhostState.RETURN;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        CheckTrigger();

        if (state == GhostState.WANDER) {
            if (agent.remainingDistance <= 1.0f)
            {
                float x = UnityEngine.Random.Range(-50.0f, 50.0f);
                float z = UnityEngine.Random.Range(-50.0f, 50.0f);
                agent.destination = new Vector3(x, 0.0f, z);
            }
        }
        else if (state == GhostState.CHASE) {
            agent.destination = player.transform.position;
        }
        else if (state == GhostState.RETURN) {
            agent.destination = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void CheckTrigger() {
        if (ghostTrigger.hasTriggered) {
            Console.WriteLine("Triggered");
            state = GhostState.CHASE;
        }
    }
}   