using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int coins = 0; // Jumlah koin yang dimiliki pemain
    private int scr = 0;  // Skor saat ini
    public int upgradeLevel = 0;
    public int upgradeCost = 10;
    
    [SerializeField] Text score;

    float cpt = 0;


    // Metode ini dapat dipanggil untuk menambahkan koin
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }

    // Metode ini dapat dipanggil untuk mengurangi koin
    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            Debug.Log("Coins spent. Remaining coins: " + coins);
            return true;
        }
        else
        {
            Debug.Log("Not enough coins!");
            return false;
        }
    }

    // Metode untuk menyimpan koin jika target skor tercapai
    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
        Debug.Log("Coins saved.");
    }

    // Metode untuk memuat data koin dari PlayerPrefs
    public void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }

    private void OnApplicationQuit()
    {
        // Simpan koin saat aplikasi ditutup
        SaveCoins();
    }

    private void Start()
    {
        LoadCoins();

        if (coins == 2 )
        {
            coins = 0;
            SaveCoins();  // Simpan kondisi reset ini
        }
    }

    // Metode untuk memperbarui skor
    void setScore()
    {
        cpt += Time.deltaTime;
        if (cpt >= 0.5f)
        {
            cpt = 0f;
            scr++;
            score.text = scr.ToString("0000");

            // Simpan koin jika target skor tercapai
            SaveCoins();
        }
    }
}
