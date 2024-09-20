using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    // Reference til din NPC prefab
    public GameObject npcPrefab;

    // Antal NPC'er du vil spawne
    public int numberOfNPCs = 100;

    // Spawn radius
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnNPCs();
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

            // Eventuelle tilpasninger på de instancerede NPC'er kan foretages her
            newNPC.name = "NPC_" + i;  // For at give hver NPC et unikt navn
        }
    }
}
