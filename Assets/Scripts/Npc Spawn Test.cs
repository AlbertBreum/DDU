using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    // Variabel til at henvise til NPC prefab
    public GameObject npcPrefab;

    // Antallet af NPC'er, der skal spawnes
    public int numberOfNPCs = 100;

    // Området, hvor NPC'er skal spawnes
    public float spawnAreaSize = 10f;

    void Start()
    {
        // Loop for at spawne alle NPC'erne
        for (int i = 0; i < numberOfNPCs; i++)
        {
            // Generer en tilfældig position inden for spawnområdet
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize), // X position
                0,                                           // Y position (hvis det er 2D, sæt dette som 0)
                Random.Range(-spawnAreaSize, spawnAreaSize)  // Z position
            );

            // Spawner NPC'en ved den tilfældige position
            Instantiate(npcPrefab, randomPosition, Quaternion.identity);
        }
    }
}
