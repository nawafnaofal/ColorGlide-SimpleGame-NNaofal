using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab koin yang akan di-spawn
    public Transform playerTransform; // Referensi ke posisi pemain
    public float spawnRadius = 5f; // Jarak maksimal dari pemain di mana koin akan muncul
    public float spawnInterval = 2f; // Interval waktu antara spawn koin

    private void Start()
    {
        // Mulai coroutine untuk spawn koin secara periodik
        StartCoroutine(SpawnCoinCoroutine());
    }

    IEnumerator SpawnCoinCoroutine()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoin()
    {
        // Menentukan posisi acak di sekitar pemain
        Vector2 spawnPosition = playerTransform.position + (Vector3)Random.insideUnitCircle * spawnRadius;

        // Spawn koin di posisi yang telah ditentukan
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
