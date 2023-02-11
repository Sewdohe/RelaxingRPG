using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName, description;
    public int coinValue;
    public Sprite itemSprite;
    public int amountToChange;
    public bool effectHP, effectMP, effectStrength;

    [Header("Weapon/Armor Details")]
    public int weaponStrength, armorStrength;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
