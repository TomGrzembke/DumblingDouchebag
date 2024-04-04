using System;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    
    [Header("Floats")]
    private const float BulletDistanceUntilDestroy = 25;
    private float currentBulletDamage;
    [SerializeField] public float bulletSpeed = 38f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        var popCornParticles = GetComponentInParent<Transform>().transform.GetChild(0).GetComponent<ParticleSystem>();
        popCornParticles.transform.position = gameObject.transform.position;
        popCornParticles.Play();
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 3);
                
        foreach (var enemy in hitEnemies)
        {
            //Gull death
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.GetComponent<Seagull>())
        {
            Destroy(gameObject);
        }
        else
        {
            var seaGull = col.gameObject.GetComponent<Seagull>();
        }
    }
    
    public void LaunchInDirection(Vector2 shootDirection)
    {
        rb.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
