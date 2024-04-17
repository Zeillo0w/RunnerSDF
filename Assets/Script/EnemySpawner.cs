using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Préfab d'ennemi à spawner
    public Transform[] spawnPoints;  // Positions de spawn des ennemis
    public float spawnInterval = 2f;  // Intervalle entre les spawns

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);  // Appeler SpawnRandomEnemy à intervalles réguliers
    }

    void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);  // Sélectionner une position de spawn aléatoire
        Vector3 spawnPosition = spawnPoints[randomIndex].position;  // Obtenir la position de spawn sélectionnée

        // Instantier l'ennemi à la position de spawn et avec la rotation par défaut
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
