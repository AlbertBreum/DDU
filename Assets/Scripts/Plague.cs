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
    public ParticleSystem plagueParticles;
    public List<Human> nearbyHumans;
    public float immunityTime = 30f; //Immunitetstiden, som default er 30 sekunder
    public DagNatCyclus timer;
    public float criticalTime = 300f;

    // Start is called before the first frame update
    void Start()
    {
        infectedHuman = GetComponent<Human>();
        nearbyHumans = GetComponent<Human>().nearbyHumans;
        plagueParticles = GetComponent<Human>().Plague;
        plagueParticles.Play();
        GetComponent<Renderer>().material.color = Color.green;
        timer = GameObject.Find("CyklusController").GetComponent<DagNatCyclus>();
    }

    void InfectOthers() //Inficerer med pesten
    {
        float timeOfDay = timer.currentTimeOfDay;
        float InfectionChance(float r, float time)
        {
            float risk;
            risk = Mathf.Exp(-Mathf.Pow(r, 2) / radiusOfInfection);
            if (time <= criticalTime)
            {
                return risk / 250;
            }
            else
            {
                return risk / 25;
            }
        }

        foreach (Human human in nearbyHumans)
        {
            if (human == null)
            {
                continue;
            }
            float r = Vector3.Magnitude(infectedHuman.transform.position-human.transform.position);
            float time = Time.time;
            float infectionChance = InfectionChance(r, timeOfDay); //Stor afstand = stort tal, lille afstand = lille værdi
            float num = Random.Range(0f, 1f); //Stor max-værdi for stor afstand
            //Lille afstand gør, at num får en meget begrænset størrelse og nemmere kan komme under tærskelværdien
            if (num < infectionChance && human.GetComponent<Plague>() == null && time > human.timeStamp + immunityTime) //Der skal gå 40 sekunder fra immunitetstiden
            {
                //human.activeDisease = anyDisease;
                //Plague sc = gameObject.AddComponent(typeof(Plague)) as Plague;
                //Debug.Log("Human " + human + " has been infected!");
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
        float time = timer.currentTimeOfDay;
        float n = Random.Range(1, 1000000);
        if (n <= plagueTime && time < criticalTime)
        {
            //plagueParticles.Stop();
            //infectedHuman.activeDisease = Disease.None;
            //infectedHuman.currentState = State.Incubation;
            //Debug.Log("I've just been cured!");
            plagueParticles.Stop();
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(GetComponent<Plague>());
            infectedHuman.timeStamp = Time.time; //Immunitetstiden opdateres
            Debug.Log(time);
        }
    }

    void Die()
    {
        float n = Random.Range(1, 1000000);
        if (n <= 10+Mathf.Pow(plagueTime/10, 2))
        {
            Debug.Log("I've been killed by the Plague!");
            plagueParticles.Stop();
            Destroy(infectedHuman.gameObject);
        }
    }
}
