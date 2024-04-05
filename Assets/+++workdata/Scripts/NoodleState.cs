using MyBox;
using System.Collections;
using UnityEngine;

public class NoodleState : MonoBehaviour
{
    public enum NoodState
    {
        Unfilled,
        Filled,
        Steamed,
        Deployed
    }

    #region serialized fields
    public NoodState NoodStat => noodState;
    [SerializeField] NoodState noodState;
    [SerializeField] Sprite noodFilled;
    [SerializeField] Sprite noodFolded;
    [SerializeField] SpriteRenderer noodRenderer;
    #endregion

    #region private fields

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meat"))
        {
            collision.gameObject.SetActive(false);
            noodRenderer.sprite = noodFilled;
            noodState = NoodState.Filled;
        }
        else if (collision.CompareTag("Steam"))
        {
            noodState = NoodState.Steamed;
            StartCoroutine(SteamDelay());
        }
    }

    [ButtonMethod]
    public void Steam()
    {
        noodState = NoodState.Steamed;
    }

    IEnumerator SteamDelay()
    {
        yield return new WaitForSeconds(.45f);
        noodRenderer.sprite = noodFolded;
    }
}