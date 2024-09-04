using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Covid : MonoBehaviour
{
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
       GameObject g1 = new GameObject("g1");
        Human human = new Human();
        g1.AddComponent<Human>();

        g1.GetComponent<Human>().Age = 10;
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
