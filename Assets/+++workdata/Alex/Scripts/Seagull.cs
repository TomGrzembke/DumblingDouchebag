using System.Collections;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rbEnemy;
    private SpriteRenderer sr;

    [Header("Booleans")]
    public bool enemyCanMove = true;
    public bool enemyWaiting;

    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        
        sr = GetComponent<SpriteRenderer>();
    }
    
    private void TargetRide()
    {
        var relativePos = transform.InverseTransformPoint(transform.position);
        
        sr.flipX = !(relativePos.x > 0);
    }

    //Here I stop the time for a hit stop and set the hurt animation before that, then I start a coroutine which keeps going when time is 0
    public void Stop(float duration)
    {
        if (enemyWaiting)
        {
            return;
        }
        
        GetComponent<Animator>().SetTrigger("Hurt");
        
        StartCoroutine(EnemyGotHit(duration));
    }
    
    private IEnumerator EnemyGotHit(float duration)
    {
        enemyWaiting = true;

        yield return new WaitForSecondsRealtime(duration);
        
        //AudioManager.Instance.Play("EnemyHit");

        enemyWaiting = false;
    }
    
    private void OnDestroy()
    {
        //Play particles
    }
}
