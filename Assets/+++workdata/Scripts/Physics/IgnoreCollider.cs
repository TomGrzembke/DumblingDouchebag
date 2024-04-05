using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,8);
    }
}