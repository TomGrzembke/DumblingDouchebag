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
    [SerializeField] AnimationCurve grappleCurve;
    Coroutine moveCor;
    #endregion

    #region private fields

    public bool canMoveGrapple;
    
    #endregion

    void Start()
    {
        InputManager.Instance.SubscribeTo(Move, InputManager.Instance.moveAction);
    }

    void Move(InputAction.CallbackContext ctx)
    {
        if(canMoveGrapple)
        {
            if (moveCor != null)
                StopCoroutine(moveCor);

            if (InputManager.Instance.MovementVec.y > 0)
                currentTarget = fillingPos;
            else if (InputManager.Instance.MovementVec.x < 0)
                currentTarget = fillPos;
            else if (InputManager.Instance.MovementVec.y < 0)
                currentTarget = steamPos;
            else if (InputManager.Instance.MovementVec.x > 0)
            {
                StopCoroutine(moveCor);
                moveCor = StartCoroutine(MoveDumpling());
                return;
            }

            moveCor = StartCoroutine(MoveGrapple());
        }
    }

    IEnumerator MoveGrapple()
    {
        Vector3 startGrapple = grappling.position;
        float movedTime = 0;

        while (movedTime < moveTime)
        {
            movedTime += Time.deltaTime;
            grappling.position = Vector3.Lerp(startGrapple, currentTarget.position, grappleCurve.Evaluate(movedTime / moveTime));
            yield return null;
        }

    }

    IEnumerator MoveDumpling()
    {
        Vector3 startGrapple = grappling.position;
        float movedTime = 0;

        while (movedTime < moveTime)
        {
            movedTime += Time.deltaTime;
            grappling.position = Vector3.Lerp(startGrapple, fillPos.position, movedTime / moveTime);
            yield return null;
        }

        startGrapple = grappling.position;
        movedTime = 0;
        currentTarget = deployPos;

        while (movedTime < moveTime)
        {
            movedTime += Time.deltaTime;
            grappling.position = Vector3.Lerp(startGrapple, deployPos.position, movedTime / moveTime); ;
            yield return null;
        }
    }
}