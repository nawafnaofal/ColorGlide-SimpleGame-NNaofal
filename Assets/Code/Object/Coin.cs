using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Nilai koin yang akan ditambahkan ke skor atau jumlah koin pemain

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah objek yang menabrak koin adalah pemain
        if (other.CompareTag("Player"))
        {
            // Akses skrip PlayerData atau sistem yang menangani koin pemain
            PlayerData playerData = other.GetComponent<PlayerData>();
            if (playerData != null)
            {
                // Tambahkan nilai koin ke jumlah koin pemain
                playerData.AddCoins(coinValue);

                // Hancurkan objek koin setelah dikumpulkan
                Destroy(gameObject);
            }
        }
    }
}


