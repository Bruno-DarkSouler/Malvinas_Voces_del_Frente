using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public PlayerStates playerStates;
    public TimeManager timeManager;
    public float coldMultiplier;
    public float hungerMultiplier;
    public float thirstMultiplier;

    [Header("Stats to increase and decrease")]
    public float coldToIncrease;

    private float updateStatesTime;

    private bool nightCold;
    private bool nightColdApplied;

    void Start()
    {
        coldMultiplier = 1;
        hungerMultiplier = 1;
        thirstMultiplier = 1;

        coldToIncrease = 20;

        updateStatesTime = 0f;

        nightCold = true;
        nightColdApplied = false;
    }

    void Update()
    {
        // Debug.Log(timeManager.timePassed);
        if(timeManager.timePassed - updateStatesTime >= 100f)
        {
            updateStatesTime = timeManager.timePassed;
            //playerStates.increaseThirst(10 * thirstMultiplier);
            //playerStates.increaseHunger(10 * hungerMultiplier);
            playerStates.increaseCold(coldToIncrease * coldMultiplier);
            if(playerStates.cold >= 100)
            {
                playerStates.DecreaseHP(5);
            }
            // Debug.Log(updateStatesTime);
        }

        //ManageNightCold();
    }

    void ManageNightCold()
    {
        if (timeManager.hours > 20 || timeManager.hours < 7)
        {
            nightCold = true;
        }
        else
        {
            nightCold = false;
            nightColdApplied = false;
            coldToIncrease -= 7;
            if (coldToIncrease < 0)
            {
                coldToIncrease = 0;
            }
        }

        if (nightCold && !nightColdApplied)
        {
            coldToIncrease += 7;
            if (coldToIncrease > 100)
            {
                coldToIncrease = 100;
            }
            nightColdApplied = true;
        }

        
    }
}
