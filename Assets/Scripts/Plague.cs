using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plague : MonoBehaviour
{
    private Human infectedHuman;
    private float plagueTime;
    ParticleSystem plagueParticles;

    // Start is called before the first frame update
    void Start()
    {
        plagueParticles = GetComponent<Human>().Plague;
        plagueParticles.Play();

    }

    // Update is called once per frame
    void Update()
    {
        plagueTime += Time.deltaTime;
        CureDisease();
        Die();
    }

    void CureDisease()
    {
        float n = Random.Range(1, 100000);
        if (n <= 5*plagueTime)
        {
            //plagueParticles.Stop();
            infectedHuman.activeDisease = Disease.None;
            infectedHuman.currentState = State.Incubation;
            
        }
    }

    void Die()
    {
        float n = Random.Range(1, 100000);
        if (n <= 120 + plagueTime)
        {
            plagueParticles.Stop();
            Destroy(infectedHuman);
        }
    }
}
