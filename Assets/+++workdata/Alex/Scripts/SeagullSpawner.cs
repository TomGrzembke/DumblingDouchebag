using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeagullSpawner : MonoBehaviour
{
    private Seagull seagull;
    [SerializeField] private List<SpawnPoint> spawnPoints;

    private void StartSeagullGame()
    {
        StartCoroutine(SpawnSeagull());
    }
    
    private IEnumerator SpawnSeagull()
    {
        Instantiate(seagull, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        StartCoroutine(SpawnSeagull());
    }
}
