using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Backpack = new List<GameObject>();
    [SerializeField] private GameObject inventory;
    [SerializeField] private int ID;
    public topdownmovent player;
    public bool lifeInv;
    public GameObject selector;
    public PlayerStates playerStates;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("item"))
        {
            for (int i = 0; i < Backpack.Count; i++)
            {
                if (Backpack[i].GetComponent<Image>().enabled == false)
                {
                    Backpack[i].GetComponent<Image>().enabled = true;
                    Backpack[i].GetComponent<Image>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }
    }

    void Start()
    {
        player = FindObjectOfType<topdownmovent>();
        inventory.SetActive(false);
        lifeInv = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            lifeInv = !lifeInv;
            inventory.SetActive(lifeInv);
        }

        if(lifeInv == true)
        {
            player.speed = 0;
        }
        else
        {
            player.speed = 8;
        }
        Navegacion();
    }

    void Navegacion(){
        if(Input.GetKeyDown(KeyCode.D) && ID < Backpack.Count-1){
            ID++;
        }
        if(Input.GetKeyDown(KeyCode.A) && ID > 0){
            ID--;
        }
        if(Input.GetKeyDown(KeyCode.W) && ID > 3){
            ID -= 4;
        }
        if(Input.GetKeyDown(KeyCode.S) && ID < 4){
            ID += 4;
        }

        selector.transform.position = Backpack[ID].transform.position;

        if(lifeInv && Input.GetKeyDown(KeyCode.E)){
            Image imagen = Backpack[ID].GetComponent<Image>();
            if (imagen.enabled == true)
            {
                imagen.enabled = false;
                imagen.sprite = null;
                playerStates.increaseHP(20);
                playerStates.cold = 0;
            }
        }
    }



}