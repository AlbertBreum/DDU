using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Healthy,
    Incubation,
    Infected,
    Immune
}
public enum Disease
{
    None,
    Covid,
    Plaque,
    Smallpox
}

public enum Gender
{
    Male,
    Female
}

public class Human : MonoBehaviour
{
    public List<Human> nearbyHumans = new List<Human>(); //Opretter en liste til at holde styr på mennesker indenfor smitteradius
    public float radiusOfInfection;
    public int wealth = 10;
    public Disease activeDisease;
    public State currentState;
    public int Age;

    public ParticleSystem particles;

    private void OnTriggerEnter(Collider other) //Detekterer, at et menneske kommer indenfor en given radius
    {
        //Debug.Log("enter");
        if (other.gameObject.tag == "human")
        {
            nearbyHumans.Add(other.GetComponent<Human>());
            //Debug.Log("ADDED HUMAN");
        }
    }

    private void OnTriggerExit(Collider other) //Detekterer, at et menneske kommer udenfor en given radius
    {
        //Debug.Log("Exit");
        if (other.gameObject.tag.Equals("human"))
        {
            nearbyHumans.Remove(other.GetComponent<Human>());
        }
    }
  

   

    void InfectOthers()
    {
        float InfectionChance(float r)
        {
            float risk;
            risk = Mathf.Exp(-Mathf.Pow(r, 2) / radiusOfInfection);
            return risk;

        }

        foreach (Human human in nearbyHumans)
        {
            Debug.Log(human);
            Debug.Log("Hello");
            float num = Random.Range(0f, 1f);
            float r = 5.0f;
            if (num > InfectionChance(r))
            {
                human.activeDisease = Disease.Covid;

            }



        }



    }


}
