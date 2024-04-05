using System;
using System.Collections;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rbEnemy;
    private SpriteRenderer sr;
    private WeaponAiming player;

    [Header("Booleans")]
    private bool canMove = true;
    private bool canGetHit = true;
    private bool flyToRight;
    
    
    
    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        
        sr = GetComponent<SpriteRenderer>();

        player = FindObjectOfType<WeaponAiming>();
        
        flyToRight = player.transform.position.x > transform.position.x;
    }

    private void Update()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        if (canMove)
        {
            var relativePos = transform.InverseTransformPoint(transform.position);
        
            sr.flipX = !(relativePos.x > 0);

            if (flyToRight)
            {
                rbEnemy.AddForce(Time.deltaTime * new Vector3(20,0,0), ForceMode.Impulse);
            }
            else
            {
                rbEnemy.AddForce(Time.deltaTime * new Vector3(-20,0,0), ForceMode.Impulse);
            }
        }
    }

    //Here I stop the time for a hit stop and set the hurt animation before that, then I start a coroutine which keeps going when time is 0
    public IEnumerator Stop()
    {
        if (canGetHit)
        {
            canMove = false;

            rbEnemy.velocity = Vector3.zero;

            rbEnemy.AddForce(new Vector3(0, 10f, 0), ForceMode.Impulse);

            while (rbEnemy.velocity.y == 0)
            {
                rbEnemy.velocity = Vector3.zero;
            
                yield return new WaitForSeconds(.2f);

                sr.color = Color.red;
            
                yield return new WaitForSeconds(.2f);

                sr.color = Color.white;

                yield return new WaitForSeconds(.2f);

                sr.color = Color.red;
            
                yield return new WaitForSeconds(.2f);

                sr.color = Color.white;
            
                rbEnemy.useGravity = true;
        
                rbEnemy.drag = 0f;

                yield return null;
            }
            
            canGetHit = false;
        }
        
        //GetComponent<Animator>().SetTrigger("Hurt");
        
        //AudioManager.Instance.Play("EnemyHit");
    }

    private void OnDestroy()
    {
        //Play particles
    }
}
