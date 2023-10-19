using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SystemUang : MonoBehaviour
{
    private int playerRp = 500000; // Uang awal pemain

    [SerializeField]
    private TextMeshProUGUI uiUang;

    public int GetPlayerRp()
    {
        return playerRp;
    }

    public void AddRp(int amount)
    {
        playerRp += amount;
        Ui();
    }

    public bool DeductRp(int amount)
    {
        if (playerRp >= amount)
        {
            playerRp -= amount;
            Ui();
            return true;
        }
        return false; // Uang tidak cukup
    }

    void Ui() {
        uiUang.text = GetPlayerRp().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Ui();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
