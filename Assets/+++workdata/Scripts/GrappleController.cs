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

    void Start()
    {
        InputManager.Instance.SubscribeTo(Move, InputManager.Instance.moveAction);
    }

    void Move(InputAction.CallbackContext ctx)
    {
        if (moveCor != null)
            StopCoroutine(moveCor);

        if (InputManager.Instance.MovementVec.y > 0)
            currentTarget = fillingPos;
        else if (InputManager.Instance.MovementVec.x > 0)
            currentTarget = steamPos;
        else if (InputManager.Instance.MovementVec.y < 0)
            currentTarget = fillPos;
        else if (InputManager.Instance.MovementVec.x < 0)
            currentTarget = deployPos;

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