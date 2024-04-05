using UnityEngine;

public class DumplingWelc : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dumpling"))
        {
            Ammunition.Instance.AddAmmo();
            Destroy(other.gameObject);
        }
    }
}