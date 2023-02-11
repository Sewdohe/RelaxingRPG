using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;
    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    // Inventory Management
    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] refrenceItems;
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        } else {
            PlayerController.instance.canMove = true;
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for(int i = 0; i < refrenceItems.Length; i++)
        {
            if(refrenceItems[i].itemName == itemToGrab)
            {
                return refrenceItems[i];
            }
        }

        return null;
    }
}
