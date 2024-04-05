using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeagullSpawner : MonoBehaviour
{
    private Seagull seagull;

    private void StartSeagullGame()
    {
        StartCoroutine(SpawnSeagull());
    }
    
    private IEnumerator SpawnSeagull()
    {
        var seagullObject = Instantiate(seagull, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
    }
}
