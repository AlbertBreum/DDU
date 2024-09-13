using System.Collections;
using System.Collections.Generic;
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

    }

    void CureDisease()
    {
        float n = Random.Range(1, 100000);
        if (n <= 2*plagueTime)
        {
            infectedHuman.activeDisease = Disease.None;
            infectedHuman.currentState = State.Incubation;
        }
    }

    void Die()
    {
        float n = Random.Range(1, 100000);
        if (n <= 120 + plagueTime)
        {
            Destroy(infectedHuman);
        }
    }

}
