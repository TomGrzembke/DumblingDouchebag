using MyBox;
using UnityEngine;

public class NoodleSpawner : MonoBehaviour
{
    #region serialized fields
    [SerializeField] GameObject noodlePrefab;
    [SerializeField] Transform spawnPos;
    [SerializeField] float width;
    float spawnTime;
    float timeWentBy;

    #endregion

    public void SpawnNoodle()
    {
        Vector3 pos = spawnPos.localPosition.SetY(spawnPos.localPosition.y + Random.Range(-width, width));
        Instantiate(noodlePrefab, pos, Quaternion.identity);
    }
}