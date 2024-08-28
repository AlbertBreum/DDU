using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class NPCPathing : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    private float stoppingDistance = 0.3f;
    public List<Transform> points = new List<Transform>();
    private int posIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(moveOnTime), 4f);
    }

    void moveOnTime()
    {

        Debug.Log("yipeee" + points[posIndex]);
        agent.SetDestination(points[posIndex].position);
        agent.isStopped = false;
        Invoke(nameof(moveOnTime), 4f); //call again in 4 seconds
        posIndex = (posIndex + 1) % (points.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            agent.isStopped = true;
            //Debug.Log("agent arrived!!");
        }
    }
}

