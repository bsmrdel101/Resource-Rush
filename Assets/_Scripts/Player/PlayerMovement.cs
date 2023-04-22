using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    private Vector3 playerInput;
    private float _horizontal, _vertical;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    private void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        playerInput = new Vector3(_horizontal, _vertical, 0);
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.MovePosition(transform.position + playerInput * Time.deltaTime * moveSpeed);
    }
}
