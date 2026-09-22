using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float lifetime;
    public enrmigo lifeEnemy;
    public controlCamara damage;
    void Start()
    {
        StartCoroutine(DeathDelay());
        lifeEnemy = FindObjectOfType<enrmigo>();
        damage = FindObjectOfType<controlCamara>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            if (lifeEnemy.enemyHP != 0)
            {
                lifeEnemy.enemyHP -= damage.enemyDamage;
                Destroy(gameObject);
            }
        }
    }
}

