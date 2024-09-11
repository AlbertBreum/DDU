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
    ParticleSystem particlesystem;

    // Start is called before the first frame update

    void Start()
    {
        timer = GameObject.Find("CyklusController").GetComponent<DagNatCyclus>();
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(moveOnTime), 0f);
        particlesystem = GetComponent<Human>().particles;
    }

    
    public enum Activity
    {
        Work,
        Free,
        Asleep,
        Infected
    }
    public Activity CurrentActivity;
    void moveOnTime()
    {

        Debug.Log("Den aktuelle tid: " + timer.currentTimeOfDay);
        if (timer.currentTimeOfDay <= 40f && timer.currentTimeOfDay < 180f)
        {
            //agent.SetDestination(points[0].position);
            Work();
        }
        else if (timer.currentTimeOfDay >= 180 && timer.currentTimeOfDay < 300)
        {
            //agent.SetDestination(points[1].position);
            Free();
        }
        else if (timer.currentTimeOfDay >= 300 && timer.currentTimeOfDay < 420 || timer.currentTimeOfDay >= 0 && timer.currentTimeOfDay < 40f)
        {
            //agent.SetDestination(points[2].position);
            Asleep();
        }
        agent.isStopped = false;
        
    }
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
        if(!IsWorking)
        {
            agent.SetDestination(points[0].position);


        }
    }
    
    void Free()
    {
        if(IsFree)
        {
            Debug.Log("Off work");
            agent.SetDestination(points[1].position);
        }
        // Her skal NPC'erne kunne finde fra deres arbejde hen til at sted hvor de kan slappe af
        
    }
    void Asleep()
    {
        if(IsAsleep)
        {
            agent.SetDestination(points[2].position);
        }
        // Her skal NPC'erne kunne finde hjem til deres hus og bliver der indtil det bliver dag igen
    }
    void Infected()
    {
        if(Isinfected)
        {

        }
        // Her skal NPC'en fors�tte sin normale hverdag men med mulighed for�at smitte andre omkring sig
    }
}