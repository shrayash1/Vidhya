using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Serialization;

public enum MovementState
{
    Idle,
    Moving,
    Attack
}
[System.Serializable]
public class AnimationNames
{
    public string IDLE_BACK = "Idle_back";
    public string IDLE_FRONT = "Idle_front";
    public string IDLE_LEFT = "Idle_left";
    public string IDLE_RIGHT = "Idle_right";
    public string WALK_FRONT = "Walk_front";
    public string WALK_BACK = "Walk_back";
    public string WALK_LEFT = "Walk_left";
    public string WALK_RIGHT = "Walk_right";
}
public class MovementScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private LayerMask collideables;
    
    private Vector3 targetPos;
    private bool isMoving = false;
    private float boxCastDistance = 0.45f;
    private Vector2 boxCastSize = new Vector2(0.8f,0.8f);

    private RaycastHit2D hit;
    private Vector2 movePos;
    private static readonly int IsBumping = Animator.StringToHash("isBumping");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        { 
            MoveCharacter();
        }
        animator.SetBool(IsMoving,isMoving);
    }

    private void MoveCharacter()
    {
        movePos = playerInput.GetMovementVectorNormalized();
        //Debug.Log(movePos);
        if (movePos.x != 0)
            movePos.y = 0;


        if (movePos != Vector2.zero)
        {
            animator.SetFloat("moveX",movePos.x);
            animator.SetFloat("moveY",movePos.y);
            targetPos = transform.position;
            targetPos.x += movePos.x;
            targetPos.y += movePos.y;
        }
        if (!ReturnWalkable(targetPos))
        {
            StartCoroutine(Move(targetPos));
        }
        else
        {
            animator.SetBool(IsBumping, true);
        }
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

    private bool ReturnWalkable(Vector3 targetPosition)
    {
        if (Physics2D.BoxCast(targetPosition, boxCastSize, 0f, Vector2.zero,boxCastDistance,collideables))
        {
            targetPos = transform.position;
            return true;
        }
        animator.SetBool(IsBumping, false);
        return false;
        // if (Physics2D.OverlapCircle(targetPosition, overlapCircleRadius, collideables))
        // {
        //     return false;
        // }
        // return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(targetPos,boxCastSize);
    }
}
