using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagNatCyclus : MonoBehaviour
{
    // chatGPT kode behandel med et gran salt
    public Light sunLight;                      // Referencen til lyskilden (solen)
    public float dayDuration = 300f;            // Varighed af dagen i sekunder (5 minutter)
    public float nightDuration = 120f;          // Varighed af natten i sekunder (2 minutter)

    public Color dayColor = Color.white;        // Farve på lyset om dagen
    public Color nightColor = Color.blue;       // Farve på lyset om natten
    public float maxDayIntensity = 1f;          // Maksimal intensitet på lyset om dagen
    public float minNightIntensity = 0.2f;      // Minimal intensitet på lyset om natten
    public float transitionSpeed = 2f;          // Hvor hurtigt overgangen skal ske

    private float cycleDuration;                // Den samlede varighed af en dag-nat cyklus
    public float currentTimeOfDay { get; private set; } // Den aktuelle tid i cyklussen (tilgængelig for andre scripts)
    public bool isDay { get; private set; }     // Indikator for, om det er dag eller nat

    void Start()
    {
        cycleDuration = dayDuration + nightDuration;
        currentTimeOfDay = 0f;
        isDay = true;
    }

    void Update()
    {
        //Debug.Log(currentTimeOfDay);
        // Opdaterer tiden i cyklussen
        currentTimeOfDay += Time.deltaTime;

        // Skift mellem dag og nat
        if (currentTimeOfDay <= dayDuration)
        {
            // Dag-tid: Solen stiger
            isDay = true;
            sunLight.intensity = maxDayIntensity;
            sunLight.color = dayColor;

            // Rotér lyskilden for at simulere solens bevægelse
            float dayProgress = currentTimeOfDay / dayDuration;
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(dayProgress * 180f, 170f, 0f));
        }
        else if (currentTimeOfDay <= cycleDuration)
        {
            // Nat-tid: Solen falder
            isDay = false;
            sunLight.intensity = minNightIntensity;
            sunLight.color = nightColor;

            // Rotér lyskilden for at simulere solens bevægelse
            float nightProgress = (currentTimeOfDay - dayDuration) / nightDuration;
            sunLight.transform.rotation = Quaternion.Euler(new Vector3(180f + nightProgress * 180f, 170f, 0f));
        }
        else
        {
            // Reset cyklussen
            currentTimeOfDay = 0f;
        }

        // Overgang mellem dag og nat
        if (currentTimeOfDay > dayDuration - transitionSpeed && currentTimeOfDay < dayDuration)
        {
            // Transition fra dag til nat
            float t = (dayDuration - currentTimeOfDay) / transitionSpeed;
            sunLight.intensity = Mathf.Lerp(minNightIntensity, maxDayIntensity, t);
            sunLight.color = Color.Lerp(nightColor, dayColor, t);
        }
        else if (currentTimeOfDay > cycleDuration - transitionSpeed)
        {
            // Transition fra nat til dag
            float t = (cycleDuration - currentTimeOfDay) / transitionSpeed;
            sunLight.intensity = Mathf.Lerp(maxDayIntensity, minNightIntensity, t);
            sunLight.color = Color.Lerp(dayColor, nightColor, t);
        }
    }
}
