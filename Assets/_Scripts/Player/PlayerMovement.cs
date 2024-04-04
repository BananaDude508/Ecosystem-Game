using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

	public float moveSpeed = 10f;



	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		GetMovementDirection();

		transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
	}

	private Vector2 moveDirection;
	private void GetMovementDirection()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");
		moveDirection.Normalize();
	}
}