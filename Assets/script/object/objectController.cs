using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour
{
    public PlayerStates playerStates;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerStates.increaseHP(20);
            playerStates.cold = 0;
            Destroy(gameObject);
        }
    }
}
