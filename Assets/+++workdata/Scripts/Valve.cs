using UnityEngine;

public class Valve : MonoBehaviour
{
    #region serialized fields
    [SerializeField] Animator anim;
    [SerializeField] GameObject meat;
    [SerializeField] Animator steam;

    #endregion

    #region private fields

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Grapple")) return;
        meat.SetActive(false);
        anim.SetTrigger("turn");

    }
}