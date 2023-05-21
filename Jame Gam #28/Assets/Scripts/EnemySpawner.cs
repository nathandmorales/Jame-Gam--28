using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public Transform[] spawnPoints;
    public Sprite[] enemySprites; // Array to store the enemy sprite options
    public List<Vector2> availablePlaces;
    public float spawnRate = 2f;
    public int numberOfEnemies = 5;


    private int currentWave = 0;
    public int maxNumOfWaves = 10;

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

private IEnumerator SpawnEnemies()
{
    while (currentWave < maxNumOfWaves)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, availablePlaces[Random.Range(0, 17)], Quaternion.identity);
            SpriteRenderer spriteRenderer = newEnemy.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = enemySprites[Random.Range(0, enemySprites.Length)];
        }

        // Wait until all enemies from the previous wave are defeated
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
        yield return new WaitForSeconds(spawnRate); // Optional delay between waves

        currentWave++;
        // Increase difficulty for the next wave (e.g., increase spawnRate or numberOfEnemies)
    }
}
}