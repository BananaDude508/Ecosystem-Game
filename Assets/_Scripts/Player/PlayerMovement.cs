using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 10f;
	public float stopDragForce = 2f;

	private Vector2 moveDirection;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		
	}
	private void FixedUpdate()
	{
		GetMovementDirection();

		rb.AddForce(moveDirection * moveSpeed - rb.velocity);
	}

	private void GetMovementDirection()
	{
		moveDirection.x = Input.GetAxis("Horizontal");
		moveDirection.y = Input.GetAxis("Vertical");
		moveDirection.Normalize();
	}
}
