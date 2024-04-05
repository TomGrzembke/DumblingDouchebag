using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeagullSpawner : MonoBehaviour
{
    [SerializeField] private Seagull seagull;
    [SerializeField] private List<SpawnPoint> spawnPoints;
    public static SeagullSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnSeagull());
    }

    private IEnumerator SpawnSeagull()
    {
        Instantiate(seagull, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        StartCoroutine(SpawnSeagull());
    }
}
