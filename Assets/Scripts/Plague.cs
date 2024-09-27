using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Plague : MonoBehaviour
{
    public float radiusOfInfection = 2f;
    private Human infectedHuman;
    private float plagueTime;
    ParticleSystem plagueParticles;
    public List<Human> nearbyHumans;

    // Start is called before the first frame update
    void Start()
    {
        infectedHuman = GetComponent<Human>();
        nearbyHumans = GetComponent<Human>().nearbyHumans;
        plagueParticles = GetComponent<Human>().Plague;
        plagueParticles.Play();
        GetComponent<Renderer>().material.color = Color.green;

    }

    void InfectOthers() //Inficerer med pesten
    {
        float InfectionChance(float r)
        {
            float risk;
            risk = Mathf.Exp(-Mathf.Pow(r, 2) / radiusOfInfection);
            return risk;
        }

        foreach (Human human in nearbyHumans)
        {
            if (human == null)
            {
                continue;
            }
            float num = Random.Range(0f, 1f);
            float r = Vector3.Magnitude(infectedHuman.transform.position-human.transform.position);

            if (num/2500 > InfectionChance(r) && human.GetComponent<Plague>() == null)
            {
                //human.activeDisease = anyDisease;
                //Plague sc = gameObject.AddComponent(typeof(Plague)) as Plague;
                Debug.Log("Human " + human + " has been infected!");
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
        if (n <= 2*plagueTime)
        {
            //plagueParticles.Stop();
            //infectedHuman.activeDisease = Disease.None;
            //infectedHuman.currentState = State.Incubation;
            Debug.Log("I've just been cured!");
            plagueParticles.Stop();
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(GetComponent<Plague>());

        }
    }

    void Die()
    {
        float n = Random.Range(1, 100000);
        if (n <= 40 + plagueTime)
        {
            Debug.Log("I've been killed by the Plague!");
            plagueParticles.Stop();
            Destroy(infectedHuman.gameObject);
        }
    }
}
