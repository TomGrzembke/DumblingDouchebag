using System.Collections;
using UnityEngine;

public class NoodleState : MonoBehaviour
{
    public enum NoodState
    {
        Unfilled,
        FilledAndBound,
        Steamed,
        Deployed
    }

    #region serialized fields
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
            noodState = NoodState.Unfilled;
        }
        if (collision.CompareTag("Steam"))
        {
            noodState = NoodState.Steamed;
            StartCoroutine(SteamDelay());
        }
    }

    IEnumerator SteamDelay()
    {
        yield return new WaitForSeconds(.7f);
        noodRenderer.sprite = noodFolded;
    }
}