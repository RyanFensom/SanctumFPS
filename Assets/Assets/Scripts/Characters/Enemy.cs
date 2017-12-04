using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour
{
    public NetworkGoal goal;
    NavMeshAgent agent;
    [SyncVar]
    public float health = 20;
    public float damage = 5;
    private float distToGoal;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        goal = FindObjectOfType<NetworkGoal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            RpcDie();
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    goal.health--;
                }
            }
        }
    }

    // Used to navigate towards the goal
    void SeekGoal()
    {

    }

    // Destroy enemy
    [ClientRpc]
    void RpcDie()
    {
        Destroy(gameObject);
        NetworkServer.UnSpawn(gameObject);
    }
}
