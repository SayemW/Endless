using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn obstacles by pooling. Instead of destroying objects and 
/// instantiating new ones we simply reuse the columns.
/// </summary>
public class ColumnSpawner : MonoBehaviour
{
    // Column prefab
    [SerializeField]
    GameObject[] columnPrefab;

    // Number of columns to spawn in
    const int ColumnPoolSize = 5;

    // Game object array containing out columns
    // idx 0 = standard column
    // idx 1 = stagger column
    // idx 2 = spinning column
    // idx 3 = moving column
    GameObject[,] columns;

    // Initial instantiate position
    Vector2 objectPoolPosition;

    // Set timer to spawn new column
    float timeSinceLastSpawn;

    // column Spawn rate
    const float SpawnRate = 3;
        
    // Set column parameters
    const float ColumnMin = 2;
    const float ColumnMax = -2;

    // Index of current column for each type of columns
    int[] columnIndex;

    // Spawn location vector
    Vector2 spawnVector;

    // Start is called before the first frame update
    void Start()
    {
        // Set location of object spawn
        // We will spawn the initial columns offscreen
        objectPoolPosition = new Vector2(-15, -25);

        // Create the array of different types of obstacles
        columns = new GameObject[4, ColumnPoolSize] ;

        // Instantaite the gameObjects
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            columns[0, i] = (GameObject)Instantiate(columnPrefab[0], objectPoolPosition, Quaternion.identity);
            columns[1, i] = (GameObject)Instantiate(columnPrefab[1], objectPoolPosition, Quaternion.identity);
            columns[2, i] = (GameObject)Instantiate(columnPrefab[2], objectPoolPosition, Quaternion.identity);
            columns[3, i] = (GameObject)Instantiate(columnPrefab[3], objectPoolPosition, Quaternion.identity);
        }

        // Initialize last spawn time
        timeSinceLastSpawn = 0;

        // The index of current column from the array
        columnIndex = new int[4];

        // Initialize spawn vector
        spawnVector = new Vector2();

        // Location of new obstacle spawn
        spawnVector.x = 13;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= SpawnRate)
        {
            timeSinceLastSpawn = 0;
            moveColumnIntoFrame(Random.Range(0, 4));
        }
    }

    /// <summary>
    /// Based on the input we will bring a column obstacle into frame
    /// </summary>
    /// <param name="index"></param>
    void moveColumnIntoFrame(int index)
    {
        spawnVector.y = Random.Range(ColumnMin, ColumnMax);
        columns[index, columnIndex[index]].transform.position = spawnVector;
        columnIndex[index] = (columnIndex[index] + 1) % ColumnPoolSize;
    }
}
