using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Plague : MonoBehaviour
{
    public float radiusOfInfection = 0.5f;
    private Human infectedHuman;
    private float plagueTime;
    ParticleSystem plagueParticles;
    public List<Human> nearbyHumans;

    // Start is called before the first frame update
    void Start()
    {
        nearbyHumans = GetComponent<Human>().nearbyHumans;
        plagueParticles = GetComponent<Human>().Plague;
        plagueParticles.Play();

    }

    void InfectOthers() //Infekterer med pesten
    {
        float InfectionChance(float r)
        {
            float risk;
            risk = Mathf.Exp(-Mathf.Pow(r, 2) / radiusOfInfection);
            return risk;
        }

        foreach (Human human in nearbyHumans)
        {
            float num = Random.Range(0f, 1f);
            float r = 5.0f;
            if (num > InfectionChance(r))
            {
                //human.activeDisease = anyDisease;
                //Plague sc = gameObject.AddComponent(typeof(Plague)) as Plague;
                Debug.Log("Human " + human + " is infected!");
                Plague p = human.AddComponent<Plague>();
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        plagueTime += Time.deltaTime;
        InfectOthers();
        CureDisease();
        Die();
    }

    void CureDisease()
    {
        float n = Random.Range(1, 100000);
        if (n <= 5*plagueTime)
        {
            //plagueParticles.Stop();
            //infectedHuman.activeDisease = Disease.None;
            //infectedHuman.currentState = State.Incubation;
            
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
