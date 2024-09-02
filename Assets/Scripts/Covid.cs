using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Covid : MonoBehaviour
{
    
    private List<Human> nearbyHumans = new List<Human>(); //Opretter en liste til at holde styr på mennesker indenfor smitteradius
    public float radiusOfInfection;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject g1 = new GameObject("g1");
        Human human = new Human();
        g1.AddComponent<Human>();

        g1.GetComponent<Human>().Age = 10;
    }

    private void OnTriggerEnter(Collider other) //Detekterer, at et menneske kommer indenfor en given radius
    {
        Debug.Log("enter");
        if (other.gameObject.tag == "human")
        {
            nearbyHumans.Add(other.Human);
        }
    }

    private void OnTriggerExit(Collider other) //Detekterer, at et menneske kommer udenfor en given radius
    {
        if (other.gameObject.tag.Equals("human"))
        {
            nearbyHumans.Remove(other.gameObject);
        }
    }

    void InfectOthers()
    {
        float InfectionChance(float r) {
            float risk;
            risk = Mathf.Exp(-Mathf.Pow(r, 2)/radiusOfInfection);
            return risk;

        }

        foreach (var human in nearbyHumans) 
        {
            Debug.Log(human);
            Debug.Log("Hello");
            float num = Random.Range(0f, 1f);
            float r = 5.0f;
            if (num > InfectionChance(r))
            {
                human.activeDisease = Human.Disease.Covid;
                
            }



        }



    }
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    /* IEnumerator Fire()
    {
        while (true)
        {
            SelectEnemy();
            if (targetEnemy != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, kuppel.transform); //Spawner et proojektil
                bullet.transform.parent = null;
                bullet.GetComponent<Rigidbody>().velocity = CalculateVelocity(); //Giver kuglen en hastighed.
                bullet.GetComponent<Projecile>().target = targetEnemy;
                bullet.GetComponent<Projecile>().tower = this.gameObject; //this.gameObject
                Debug.Log("I have fired!");
            }
            yield return new WaitForSeconds(fireTime);
        }
    } */




}
