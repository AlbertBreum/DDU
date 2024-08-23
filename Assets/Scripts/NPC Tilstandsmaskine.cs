using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Activity
    {
        Work,
        Free,
        Asleep,
        Infected
    }
    public Activity CurrentActivity;
    private void Update()
    {
        switch(CurrentActivity)
        {
         case Activity.Work:
                Work();
                break;
         case Activity.Free:
                Free();
                break ;
         case Activity.Asleep:
                Asleep();
                break;
         case Activity.Infected:
                Infected();
                break;


        }
    }
    void Work()
    {
        // her skal NPC'erne kunne finde deres vej til arbejde
    }
    void Free()
    {
        // Her skal NPC'erne kunne finde fra deres arbejde hen til at sted hvor de kan slappe af
    }
    void Asleep()
    {
        // Her skal NPC'erne kunne finde hjem til deres hus og bliver der indtil det bliver dag igen
    }
    void Infected()
    {
        // Her skal NPC'en forsætte sin normale hverdag men md mulighed fo rat smitte andre omkring sig
    }
}
