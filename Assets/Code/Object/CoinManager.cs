using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int Coins { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        Coins = PlayerPrefs.GetInt("Coins", 0);
    }
}
