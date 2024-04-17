using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Pr�fab d'ennemi � spawner
    public Transform[] spawnPoints;  // Positions de spawn des ennemis
    public float spawnInterval = 2f;  // Intervalle entre les spawns

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);  // Appeler SpawnRandomEnemy � intervalles r�guliers
    }

    void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);  // S�lectionner une position de spawn al�atoire
        Vector3 spawnPosition = spawnPoints[randomIndex].position;  // Obtenir la position de spawn s�lectionn�e

        // Instantier l'ennemi � la position de spawn et avec la rotation par d�faut
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
