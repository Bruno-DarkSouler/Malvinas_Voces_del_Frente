using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public GameObject player;
    public float HP;
    public float hunger;
    public float thirst;
    public float cold;
    

    void Start()
    {
        HP = 100;
        hunger = 50;
        thirst = 50;
        cold = 10;
        
    }

    void Update()
    {
        dead();
    }


    //Functions for HP

    public void increaseHP(float quantity)
    {
        
        if(HP + quantity >= 100)
        {
            HP = 100;
        }
        else
        {
            HP += quantity;
        }
    }

    public void DecreaseHP(float quantity)
    {
        
        if(HP - quantity < 0)
        {
            HP = 0;
        }
        else
        {
            HP -= quantity;
        }
    }

    //Functions for cold

    public void increaseCold(float quantity)
    {
        
        if(cold + quantity >= 100)
        {
            cold = 100;
        }
        else
        {
            cold += quantity;
        }
    }

    public void decreaseCold(float quantity)
    {

        if (cold - quantity < 0)
        {
            cold = 0;
        }
        else
        {
            cold -= quantity;
        }
    }

    //Functions for hunger

    public void increaseHunger(float quantity)
    {
        
        if(hunger + quantity >= 100)
        {
            hunger = 100;
        }
        else
        {
            hunger += quantity;
        }
    }

    public void decreaseHunger(float quantity)
    {
        
        if(hunger + quantity >= 100)
        {
            hunger = 100;
        }
        else
        {
            hunger += quantity;
        }
    }

    //Funcitons for thirst

    public void increaseThirst(float quantity)
    {
        
        if(thirst + quantity >= 100)
        {
            thirst = 100;
        }
        else
        {
            thirst += quantity;
        }
    }

    public void decreaseThirst(float quantity)
    {
        
        if(thirst + quantity >= 100)
        {
            thirst = 100;
        }
        else
        {
            thirst += quantity;
        }
    }

    public void dead()
    {
        if (HP <= 0)
        {
            //Debug.Log("Funciono 1");
           if(GameManager.instance != null)
            {
                //Debug.Log("Funciono 2");
                GameManager.instance.GameOver();
            }
        }
    }
}
