using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Backpack = new List<GameObject>();
    [SerializeField] private GameObject inventory;
    public topdownmovent player;
    public bool lifeInv;

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
    }
}