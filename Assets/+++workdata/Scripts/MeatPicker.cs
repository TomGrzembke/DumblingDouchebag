using UnityEngine;

public class MeatPicker : MonoBehaviour
{
    #region serialized fields
    [SerializeField] GameObject meatSprite;
    #endregion

    #region private fields

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MeatBowl"))
        {
            meatSprite.SetActive(true);
        }
    }
}