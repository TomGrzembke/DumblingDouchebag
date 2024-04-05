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

    void Update()
    {
        if (timeWentBy < spawnTime)
        {
            timeWentBy += Time.deltaTime;
        }
        else
        {
            Vector3 pos = spawnPos.localPosition.SetY(spawnPos.localPosition.y + Random.Range(-width, width));
            Instantiate(noodlePrefab, pos, Quaternion.identity);
            timeWentBy = 0;
            spawnTime = Random.Range(1, 2);
        }
    }
}