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

    bool IsWorking = false;
    bool IsFree = false;
    bool IsAsleep = false;
    bool Isinfected = false;
    // Start is called before the first frame update

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(moveOnTime), 4f);
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
        switch(CurrentActivity)
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
            moveOnTime();
            
        }
    }
    void moveOnTime()
    {
        Debug.Log("hello");
        if (IsWorking == true)
        {
            Debug.Log(points[posIndex]);
            agent.SetDestination(points[posIndex].position);
            agent.isStopped = false;
            Invoke(nameof(moveOnTime), 4f); //call again in 4 seconds
            posIndex = (posIndex + 1) % (points.Count);
        }
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
