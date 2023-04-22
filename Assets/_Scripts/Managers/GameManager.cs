using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] private int resourceMin;
    [SerializeField] private int resourceMax;
    private List<Transform> _selectedResourceSpawnPoints = new List<Transform>();

    [Header("References")]
    [SerializeField] private GameObject _orePrefab;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _fruitPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _resourceSpawns;
    [SerializeField] private Transform[] _enemySpawns;

    
    private void Start()
    {
        GenerateResources();
        StartCoroutine(SpawnEnemies());
    }

    // Choose random positions and spawn resources on them
    private void GenerateResources()
    {
        int resourceAmount = (int)Random.Range(resourceMin, resourceMax);
        
        for (int i = 0; i < resourceAmount; i++)
        {
            int randomResourceIndex = (int)Random.Range(0, _resourceSpawns.Length - 1);
            Transform resourceSpawnPos = GetSpawnPoint(randomResourceIndex);

            // Add random position to the list if it doesn't already exist
            if (!_selectedResourceSpawnPoints.Contains(resourceSpawnPos))
            {
                _selectedResourceSpawnPoints.Add(resourceSpawnPos);
            }
        }

        // Spawn in resources at their randomized spawn points
        foreach (Transform point in _selectedResourceSpawnPoints)
        {
            GameObject resourceObj = GetRandomResourceObj();
            Instantiate(resourceObj, point.position, Quaternion.identity);
        }
    }
    
    // Takes in the spawn point index on the _resourceSpawns array
    // Returns the transform of the spawn point
    private Transform GetSpawnPoint(int index) => _resourceSpawns[index].transform;

    // Returns a random type of resource
    private GameObject GetRandomResourceObj()
    {
        int randNum = (int)Random.Range(0, 3);
        if (randNum == 0)
            return _orePrefab;
        else if (randNum == 1)
            return _treePrefab;
        else
            return _fruitPrefab;
    }


    // Start spawning enemies
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Transform randEnemySpawn = _enemySpawns[(int)Random.Range(0, _enemySpawns.Length - 1)];
            Instantiate(_enemyPrefab, randEnemySpawn.position, Quaternion.identity);
        }
    }
}
