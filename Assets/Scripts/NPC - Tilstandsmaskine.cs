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
    public NavMeshAgent agent;
    private float StoppingDistance = 2.8f;
    public List<Transform> points = new List<Transform>();
    //private int posIndex = 0;
    public DagNatCyclus timer;
    [Range(5, 100)] public float speed;
    [Range(1, 500)] public float walkradius;

    bool IsWorking = false;
    bool IsFree = false;
    bool IsAsleep = false;
    bool Isinfected = false;
    ParticleSystem plagueParticles;


    // Start is called before the first frame update

    void Start()
    {
        timer = GameObject.Find("CyklusController").GetComponent<DagNatCyclus>();
        agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(moveOnTime), 0f);
        //plagueParticles = GetComponent<Human>().Plague;
        if (agent != null)
        {
            agent.speed = speed;
        }
    }
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 FinalPosition = Vector3.zero;
        Vector3 RandomPostion = Random.insideUnitSphere * walkradius;
        RandomPostion += transform.position;
        if (NavMesh.SamplePosition(RandomPostion, out NavMeshHit Hit, walkradius, 1))
        {
            FinalPosition = Hit.position;
        }
        return (FinalPosition);
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

        //Debug.Log("Den aktuelle tid: " + timer.currentTimeOfDay);
        if (timer.currentTimeOfDay >= 4f && timer.currentTimeOfDay < 18f)
        {
            //agent.SetDestination(points[0].position);
            CurrentActivity = Activity.Work;
            //plagueParticles.Start();
            //Debug.Log("Stopped particles");
        }
        else if (timer.currentTimeOfDay >= 18f && timer.currentTimeOfDay < 30f)
        {
            //agent.SetDestination(points[1].position);
            //Free();
            CurrentActivity = Activity.Free;

        }
         else if (timer.currentTimeOfDay >= 30f && timer.currentTimeOfDay < 42f || timer.currentTimeOfDay >= 0f && timer.currentTimeOfDay < 4f)
         {
             //agent.SetDestination(points[2].position);
             //Asleep();
             
             //Debug.Log("Started particles");
             CurrentActivity = Activity.Asleep;
            //plagueParticles.Stop();
         }
        agent.isStopped = false;
        
    }
    private void Update()
    {
        moveOnTime();
        if (agent.remainingDistance <= StoppingDistance && !agent.pathPending)
        {
            agent.isStopped = true;
            //Debug.Log("agent arrived!!");
        }
        //Debug.Log(CurrentActivity);
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
        //agent.SetDestination(points[0].position);
        if (agent != null && agent.remainingDistance <= StoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
        }
        

    }
    
    void Free()
    {
            //Debug.Log("Off work");
            //agent.SetDestination(points[1].position);
        if(!IsFree)
        {
            if (agent != null && agent.remainingDistance <= StoppingDistance)
            {
                agent.SetDestination(RandomNavMeshLocation());
                
                Debug.Log("Once");
            }
            

        }
        //if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            //agent.SetDestination(RandomNavMeshLocation());
            
        }
        //else if(agent.remainingDistance >= 60f)
        {
            //agent.SetDestination(points[1].position);
        }
        // Her skal NPC'erne kunne finde fra deres arbejde hen til at sted hvor de kan slappe af

    }
    void Asleep()
    {
        if(!IsAsleep)
        {
            if (agent != null && agent.remainingDistance <= StoppingDistance)
            {
                agent.SetDestination(RandomNavMeshLocation());
            }
        }
       
        // Her skal NPC'erne kunne finde hjem til deres hus og bliver der indtil det bliver dag igen
    }
    void Infected()
    {
        if(Isinfected)
        {
            plagueParticles.Play();
            if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(RandomNavMeshLocation());

            }
           // else if (agent.remainingDistance >= 25f)
            {
                //agent.SetDestination(points[1].position);
            }
        }
        // Her skal NPC'en forsætte sin normale hverdag men med mulighed for´at smitte andre omkring sig
    }
}