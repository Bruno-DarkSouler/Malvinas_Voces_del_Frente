using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireEffects : MonoBehaviour
{
    private bool isNearBonfire;
    private PlayerStates playerStates;
    public TimeManager timeManager;
    private float lastUpdate;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            isNearBonfire = true;
            playerStates = collision.GetComponent<PlayerStates>();
        }

        lastUpdate = timeManager.minutes;

        Debug.Log("Entraste de la hoguera");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isNearBonfire = false;
        playerStates = null;
        Debug.Log("Saliste de la hoguera");
    }

    void Update()
    {

        if (isNearBonfire && timeManager.minutes - lastUpdate >= 1)
        {
            playerStates.cold = 0;
            lastUpdate = timeManager.minutes;
        }
    }
}
