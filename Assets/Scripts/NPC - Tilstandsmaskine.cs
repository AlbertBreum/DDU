using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class NPCBehavior : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private float stoppingDistance = 0.3f;
    public List<Transform> points = new List<Transform>();
    private int posIndex = 0;
    public DagNatCyclus timer;

    bool IsWorking = false;
    bool IsFree = false;
    bool IsAsleep = false;
    bool Isinfected = false;
    // Start is called before the first frame update

    void Start()
    {
        timer = GameObject.Find("CyklusController").GetComponent<DagNatCyclus>();
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(moveOnTime), 0f);
    }

    
    public enum Activity
    {
        Work,
        Free,
        Asleep,
        Infected
    }
    public Activity CurrentActivity;
    private void Update()
    {
        moveOnTime();
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            agent.isStopped = true;
            //Debug.Log("agent arrived!!");
        }
        switch (CurrentActivity)
        {
         case Activity.Work:
                Work();
                break;
         case Activity.Free:
                Free();
                break ;
         case Activity.Asleep:
                Asleep();
                break;
         case Activity.Infected:
                Infected();
                break;
        }
    }
    
    void Work()
    {
        // her skal NPC'erne kunne finde deres vej til arbejde
        if(IsWorking == false)
        {
            IsWorking = true;
            
        }
    }
    void moveOnTime()
    {

        Debug.Log("Den aktuelle tid: "+timer.currentTimeOfDay);
        if (timer.currentTimeOfDay >= 0f && timer.currentTimeOfDay < 7f)
        {
            agent.SetDestination(points[0].position);
        }
        else if (timer.currentTimeOfDay >= 7 && timer.currentTimeOfDay < 15)
        {
            agent.SetDestination(points[1].position);
        }
        else if (timer.currentTimeOfDay >= 15 && timer.currentTimeOfDay < 24)
        {
            agent.SetDestination(points[2].position);
        }
        agent.isStopped = false;

    }
    void Free()
    {
        if(IsFree == true)
        {
            Debug.Log("Off work");
        }
        // Her skal NPC'erne kunne finde fra deres arbejde hen til at sted hvor de kan slappe af
        
    }
    void Asleep()
    {
        // Her skal NPC'erne kunne finde hjem til deres hus og bliver der indtil det bliver dag igen
    }
    void Infected()
    {
        // Her skal NPC'en forsætte sin normale hverdag men med mulighed for´at smitte andre omkring sig
    }
}