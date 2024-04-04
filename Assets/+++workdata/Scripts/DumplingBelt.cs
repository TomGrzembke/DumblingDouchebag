using System.Collections;
using UnityEngine;

public class DumplingBelt : MonoBehaviour
{
    #region serialized fields
    [SerializeField] GameObject noodlePrefab;
    [SerializeField] Transform dumplingSpawnPos;
    [SerializeField] Transform targetTrans;
    [SerializeField] float yTollerance = 5;
    [SerializeField] float conveyerTime = 2;
    #endregion

    #region private fields

    #endregion
    IEnumerator MoveDumpling(Transform dumpling)
    {
        Vector3 dumplingStartPos = dumpling.position;

        float beldTime = 0;

        while (beldTime < conveyerTime)
        {
            beldTime += Time.deltaTime;
            dumpling.position = Vector3.Lerp(dumplingStartPos, new(targetTrans.position.x, dumpling.position.y), beldTime / conveyerTime);
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dumpling"))
        {
            StartCoroutine(MoveDumpling(collision.transform));
        }
    }

    public void SpawnNoodles()
    {

    }
}