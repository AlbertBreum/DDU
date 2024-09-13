using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    // Variabel til at henvise til NPC prefab
    public GameObject npcPrefab;

    // Antallet af NPC'er, der skal spawnes
    public int numberOfNPCs = 100;

    // Omr�det, hvor NPC'er skal spawnes
    public float spawnAreaSize = 10f;

    void Start()
    {
        // Loop for at spawne alle NPC'erne
        for (int i = 0; i < numberOfNPCs; i++)
        {
            // Generer en tilf�ldig position inden for spawnomr�det
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize, spawnAreaSize), // X position
                0,                                           // Y position (hvis det er 2D, s�t dette som 0)
                Random.Range(-spawnAreaSize, spawnAreaSize)  // Z position
            );

            // Spawner NPC'en ved den tilf�ldige position
            Instantiate(npcPrefab, randomPosition, Quaternion.identity);
        }
    }
}
