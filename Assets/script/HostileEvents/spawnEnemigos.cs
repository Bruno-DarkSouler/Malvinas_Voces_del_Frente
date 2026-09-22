using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos;
    [SerializeField] private List<Transform> puntosSpawn;
    private bool enemigosAparecieron = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void AparecerEnemigos()
    {
        if (enemigosAparecieron)
            return;
        enemigosAparecieron = true;
        foreach (GameObject enemigo in enemigos)
        {
            foreach (Transform punto in puntosSpawn)
            {
                Instantiate(enemigo, punto.position, Quaternion.identity);
            }
        }
    }
}
