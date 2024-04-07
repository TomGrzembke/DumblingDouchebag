using UnityEngine;

public class DumplingWelc : MonoBehaviour
{
    [SerializeField] private NoodleSpawner noodleSpawner;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dumpling"))
        {
            Ammunition.Instance.AddAmmo();
            Destroy(other.gameObject);
            noodleSpawner.SpawnNoodle();
        }
    }
}