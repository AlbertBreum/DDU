using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : MonoBehaviour
{
    // Reference til din NPC prefab
    public GameObject npcPrefab;

    //Vector3[] npcPoints;
    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkradius;
    private NavMeshAgent agent;
    public List<Transform> points = new List<Transform>();
    // Antal NPC'er du vil spawne
    public int numberOfNPCs = 100;
    // Spawn radius
    public float spawnRadius = 10f;
    int patientZero;

    void Start()
    {
        SpawnNPCs();
        /*Vector3 P1 = new Vector3(1, 1, 1);
        Vector3 P2 = new Vector3(1, 2, 3);

        npcPoints.Append(P1);
        npcPoints.Append(P2);*/
        agent = GetComponent<NavMeshAgent>();
        //points = GetComponent<Human>().Plague;
        patientZero = Random.Range(0,numberOfNPCs);



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

    // Funktion til at spawne NPC'er
    void SpawnNPCs()
    {
        for (int i = 0; i < numberOfNPCs; i++)
        {
            // Beregn en tilfældig position inden for en cirkel
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0; // Holder NPC'er på jorden, hvis du arbejder i 2D eller på en flad overflade

            // Instantiér NPC ved den tilfældige position
            GameObject newNPC = Instantiate(npcPrefab, randomPosition, Quaternion.identity);
            newNPC.GetComponent<NPCBehavior>().points = points;
            // Eventuelle tilpasninger på de instancerede NPC'er kan foretages her
            newNPC.name = "NPC_" + i;  // For at give hver NPC et unikt navn
                                       // newNPC.poin

            if (i == patientZero)
            {
                newNPC.AddComponent<Plague>();
                Debug.Log("Patient zero: " + patientZero);
            }


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

}
