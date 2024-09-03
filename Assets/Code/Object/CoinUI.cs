using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinText; // Referensi ke UI Text yang menampilkan jumlah koin
    private PlayerData playerData;

   
    private void Start()
    {
        // Cari PlayerData di dalam scene dengan metode yang direkomendasikan
        playerData = Object.FindFirstObjectByType<PlayerData>();

        if (playerData != null)
        {
            // Inisialisasi tampilan koin
            UpdateCoinUI(playerData.coins);
        }
        else
        {
            Debug.LogError("PlayerData not found in the scene.");
        }
    }

    private void Update()
    {
        // Perbarui UI koin setiap frame
        UpdateCoinUI(playerData.coins);
    }

    public void UpdateCoinUI(int coins)
    {
        if (playerData != null)
        {
            coinText.text = "Coins: " + playerData.coins.ToString();
        }
    }
}

