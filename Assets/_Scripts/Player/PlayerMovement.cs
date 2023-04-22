using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    private float horizontal, vertical;


    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
    }
}
