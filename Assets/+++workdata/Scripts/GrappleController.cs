using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleController : MonoBehaviour
{
    #region serialized fields
    [SerializeField] Transform grappling;
    [SerializeField] Transform fillingPos;
    [SerializeField] Transform steamPos;
    [SerializeField] Transform fillPos;
    [SerializeField] Transform deployPos;
    [SerializeField] Transform currentTarget;
    [SerializeField] float moveTime = 3;
    Coroutine moveCor;
    #endregion

    #region private fields

    #endregion

    void Awake()
    {
        InputManager.Instance.SubscribeTo(Move, InputManager.Instance.moveAction);
    }

    void Move(InputAction.CallbackContext ctx)
    {
        if (moveCor != null)
            StopCoroutine(moveCor);

        moveCor = StartCoroutine(MoveGrapple());
    }

    IEnumerator MoveGrapple()
    {
        Vector3 startGrapple = grappling.position;
        float movedTime = 0;

        while (movedTime < moveTime)
        {
            movedTime += Time.deltaTime;
            grappling.position = Vector3.Lerp(startGrapple, currentTarget.position, movedTime / moveTime);
            yield return null;
        }

    }
}