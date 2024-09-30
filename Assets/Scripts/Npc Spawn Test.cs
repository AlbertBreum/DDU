using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;



public class NPCSpawner : MonoBehaviour
{
    // Reference til din NPC prefab
    public GameObject npcPrefab;

    //Vector3[] npcPoints;
    [Range(5, 100)] public float speed;
    [Range(1, 500)] public float walkradius;
    private NavMeshAgent agent;
    public List<Transform> points = new List<Transform>();
    public List<GameObject> spawnedObjects = new List<GameObject>();
    // Antal NPC'er du vil spawne
    public const int numberOfNPCs = 100;
    // Spawn radius
    public float spawnRadius = 10f;
    //int patientZero;

    public const int PATIENT_ZERO_COUNT = 5;

    void Start()
    {
        SpawnNPCs();
        agent = GetComponent<NavMeshAgent>();
        //points = GetComponent<Human>().Plague;
        //patientZero = Random.Range(0,numberOfNPCs);



    }
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 FinalPosition = Vector3.zero;
        Vector3 RandomPostion = UnityEngine.Random.insideUnitSphere * walkradius;
        RandomPostion += transform.position;
        if (NavMesh.SamplePosition(RandomPostion, out NavMeshHit Hit, walkradius, 1))
        {
            FinalPosition = Hit.position;
        }
        return (FinalPosition);
    }

    // Funktion til at spawne NPC'er
    void SpawnNPCs()
    {
        List<int> patientZeros = PatientZeros();

        for (int i = 0; i < numberOfNPCs; i++)
        {
            // Beregn en tilfældig position inden for en cirkel
            Vector3 randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0; // Holder NPC'er på jorden, hvis du arbejder i 2D eller på en flad overflade

            // Instantiér NPC ved den tilfældige position
            GameObject newNPC = Instantiate(npcPrefab, randomPosition, Quaternion.identity);
            newNPC.GetComponent<NPCBehavior>().points = points;
            // Eventuelle tilpasninger på de instancerede NPC'er kan foretages her
            newNPC.name = "NPC_" + i;  // For at give hver NPC et unikt navn
                                       // newNPC.poin

            if (patientZeros.Contains(i))
            {
                newNPC.AddComponent<Plague>();
            }

            //if (i == patientZero)
            //{
            //  newNPC.AddComponent<Plague>();
            //Debug.Log("Patient zero: " + patientZero);
            //}


            /*if (agent != null || agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(RandomNavMeshLocation());

            }
            else
            {
                agent.SetDestination(points[1].position);
            }*/



        }


    }

    private void Update()
    {
        RandomNavMeshLocation();
    }



    public static List<int> PatientZeros()
    {
        List<int> numbers = new List<int>();

        // Fyld listen med værdier fra min til max
        for (int i = 0; i <= numberOfNPCs; i++)
        {
            numbers.Add(i);
        }

        // Shuffle listen
        for (int i = numbers.Count - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            int temp = numbers[i];
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        // Returnér de første 'count' elementer
        return numbers.GetRange(0, PATIENT_ZERO_COUNT);
    }




}