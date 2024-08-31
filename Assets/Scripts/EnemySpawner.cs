using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düşman prefab'ı
    public Transform[] spawnPoints; // Spawn noktalarının dizisi

    public float initialSpawnDelay = 5f; // İlk spawn gecikmesi
    public float spawnInterval = 20f; // Düşman spawnlama aralığı (saniye)

    private bool canSpawn = true; // Düşman spawnlamaya izin verip vermediğini kontrol eden değişken

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // İlk spawn gecikmesi
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            if (canSpawn)
            {
                SpawnEnemy();
                canSpawn = false; // Spawn işlemi yapıldıktan sonra diğer noktaların spawnlamasını engelle
            }

            // Spawn aralığı kadar bekle
            yield return new WaitForSeconds(spawnInterval);

            canSpawn = true; // Aralık tamamlandığında yeni spawn işlemine izin ver
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktası seç
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Seçilen noktada düşmanı oluştur
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
