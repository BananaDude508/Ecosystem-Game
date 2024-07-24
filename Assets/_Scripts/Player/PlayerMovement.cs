using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DayNightManager;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 moveDirection;

	public AudioSource movementAudioSource;
	public AudioClip walkingAudio;

    public float moveSpeed = 10f;
	public float slowdown = 1f;

	public bool moving = false;

	public Animator playerAnim;
	public SpriteRenderer sr;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		GetMovementDirection();
        UpdateMovementAnim();

        if (sleeping)
        {
            rb.AddForce(Vector2.zero - rb.velocity * slowdown);
            movementAudioSource.Stop();
            return;
        }

        if (!moving && moveDirection != Vector2.zero)
		{
			moving = true;
			movementAudioSource.loop = true;
			movementAudioSource.clip = walkingAudio;
			movementAudioSource.Play();

        }
		else if (moving && moveDirection == Vector2.zero)
		{
			moving = false;
            movementAudioSource.Stop();
			movementAudioSource.loop = false;
        }

        // transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        rb.AddForce(moveDirection * moveSpeed - rb.velocity * slowdown); // only move if not sleeping, always slowdown
    }

    private void GetMovementDirection()
	{
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");
		moveDirection.Normalize();
	}

	private void UpdateMovementAnim()
	{
		if (!moving || sleeping) { playerAnim.SetTrigger("Idle"); return; }

		string direction = "Idle";

		float angle = Mathf.Atan2(moveDirection.y, moveDirection.x);
		float pi = Mathf.PI;

		if (-pi / 4 < angle && angle <= pi / 4) direction = "Right";
		else if (-3*pi / 4 < angle && angle <= -pi / 4) direction = "Down";
        else if (pi / 4 < angle && angle <= 3*pi / 4) direction = "Up";
        else direction = "Left";

		playerAnim.SetTrigger(direction);

		sr.flipX = direction == "Left";
    }
}