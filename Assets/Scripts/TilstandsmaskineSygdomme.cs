using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilstandsmaskineSygdomme : MonoBehaviour
{
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

    Disease activeDisease;

    public State currentState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Healthy;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState) {
            case State.Healthy:
                Healthy();
                break;
            case State.Incubation:
                Incubation();
                break;
            case State.Infected:
                Infected();
                break;
            case State.Immune:
                Immune();
                break;
        }
    }

    void Healthy() //Skal have en normal hverdag
    {
        //FollowDailyRoutine();
    }

    void Incubation() //Skal have en normal hverdag men kan smitte
    {
        //FollowDailyroutine

        switch(activeDisease)
        {
            case Disease.Covid:
                //Indsæt kode, der gør npc'en i stand til at smitte andre
                break;
            case Disease.Plaque:
                //Indsæt kode, der gør npc'en i stand til at smitte andre
                break;
            case Disease.Smallpox:
                //Indsæt kode, der gør npc'en i stand til at smitte andre
                break;
            default:
                break;
        }
    }

    void Infected() { //Er syg og følger ikke en normal hverdag
        switch(activeDisease)
        {
            case Disease.Covid:
                Covid();
                break;
            case Disease.Plaque:
                Plaque();
                break;
            case Disease.Smallpox:
                Smallpox();
                break;
            default:
                break;
        }
    }

    void Immune() //Skal have en normal hverdag
    {
        //FollowDailyRoutine();
        //Dekrementer immunitetstiden
    }

    void Covid()
    {
        //Kør koden karakteristisk for covid
        //Dekrementer sygdomstiden
    }

    void Plaque()
    {
        //Kør koden karakteristisk for pesten
        //Dekrementer sygdomstiden
    }

    void Smallpox()
    {
        //Kør koden karakteristisk for kopper
        //Dekrementer sygdomstiden
    }

}
