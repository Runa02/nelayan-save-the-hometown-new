using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ShopItem
{
    public string NamaItem;
    public int harga;
    public bool isPurchased;
}

public class Shop : MonoBehaviour
{
    public SystemUang systemUang;
    public ShopItem[] items;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI uangText;

    void Start()
    {
        UpdateUI();
    }

    public void BuyItem(int index)
    {
        if (!items[index].isPurchased)
        {
            int itemPrice = items[index].harga;

            // Check if player has enough money to buy the item
            if (systemUang.DeductRp(itemPrice))
            {
                // Deduct money, mark item as purchased, and update UI
                items[index].isPurchased = true;
                UpdateUI();
                Debug.Log("Item " + items[index].NamaItem + " telah dibeli!");
            }
            else
            {
                // Not enough money, display a message to the player
                Debug.Log("Uangmu tidak cukup untuk membeli " + items[index].NamaItem + "!");
            }
        }
        else
        {
            // Item is already purchased, display a message to the player
            Debug.Log("Item " + items[index].NamaItem + " telah dibeli sebelumnya!");
        }
    }

    void UpdateUI()
    {
        // Update item descriptions and prices
        for (int i = 0; i < items.Length; i++)
        {
            if (!items[i].isPurchased)
            {
                itemDescriptionText.text = items[i].NamaItem + "\nharga: " + items[i].harga + " Rp";
            }
        }

        // Update player's money
        uangText.text = "Rp: " + systemUang.GetPlayerRp().ToString();
    }
}
