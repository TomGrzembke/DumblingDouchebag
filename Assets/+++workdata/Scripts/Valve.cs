using UnityEngine;

public class Valve : MonoBehaviour
{
    #region serialized fields
    [SerializeField] Animator anim;
    [SerializeField] GameObject meat;
    [SerializeField] ParticleSystem[] steam;
    [SerializeField] GameObject steamCol;
    [SerializeField] float steamTime = 4f;

    #endregion

    #region private fields

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Grapple")) return;
        meat.SetActive(false);
        anim.SetTrigger("turn");
        steamCol.SetActive(true);
        for (int i = 0; i < steam.Length; i++)
        {
            steam[i].Play();
        }
        Invoke(nameof(TurnOffSteam), steamTime);
    }

    void TurnOffSteam()
    {
        for (int i = 0; i < steam.Length; i++)
        {
            steam[i].Stop();
        }
        steamCol.SetActive(false);
    }
}