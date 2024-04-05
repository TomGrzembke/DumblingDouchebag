using MyBox;
using System.Collections;
using UnityEngine;

public class MeatPicker : MonoBehaviour
{
    #region serialized fields
    [SerializeField] GameObject meatSprite;
    [SerializeField] float moveTime = 1;
    #endregion

    #region private fields

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MeatBowl"))
        {
            meatSprite.SetActive(true);
        }

       else if (collision.TryGetComponent(out NoodleState state))
        {
            if (state.NoodStat == NoodleState.NoodState.Steamed)
            {
                StartCoroutine(MoveDumpling(state.transform));
            }
            
        }
    }

    IEnumerator MoveDumpling(Transform dumpling)
    {
        Vector3 startDumpling = dumpling.position;
        float movedTime = 0;

        while (movedTime < moveTime)
        {
            movedTime += Time.deltaTime;
            dumpling.position = Vector3.Lerp(startDumpling, startDumpling.SetX(startDumpling.x + 3), movedTime / moveTime);
            yield return null;
        }
    }
}