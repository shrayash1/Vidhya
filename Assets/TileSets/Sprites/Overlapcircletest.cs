using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlapcircletest : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask layerMask;

    private bool isTouchingGround;

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckTransform.position,groundCheckRadius);
    }
}
