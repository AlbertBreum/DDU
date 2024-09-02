using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human
{
    public int wealth = 10;


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

    public Disease activeDisease;
    public State currentState;

    public int Age;

    public enum Gender
    {
        Male,
        Female
    }





}
