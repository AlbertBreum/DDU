using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Math;

public class Covid : MonoBehaviour
{
    
    private List<GameObject> nearbyHumans = new List<GameObject>(); //Opretter en liste til at holde styr på mennesker indenfor smitteradius
    public float radiusOfInfection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) //Detekterer, at et menneske kommer indenfor en given radius
    {
        Debug.Log("enter");
        if (other.gameObject.tag == "human")
        {
            nearbyHumans.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) //Detekterer, at et menneske kommer udenfor en given radius
    {
        if (other.gameObject.tag == "human")
        {
            nearbyHumans.Remove(other.gameObject);
        }
    }

    void InfectOthers()
    {
        float InfectionChance(float r) {
            float risk;
            risk = Math.exp(-Math.Pow(r, 2)/radiusOfInfection);
            return risk;

        }

        foreach (human in nearbyHumans) {
            Console.WriteLine("Hello");
            float num = Random.Range(0f, 1f);
            float r = 5.0;
            if (num > InfectionChance(r))
            {
                human.Disease = Covid;
            }



        }



    }
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
