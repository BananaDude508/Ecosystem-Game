using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float flySpeed = 5;
    [Tooltip("The chance every second that the crow will peck at the ground, between 0 and 1")] 
    public float eatChance = 0.25f;
    int currentState = CrowState.Idle;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (currentState == CrowState.Flying)
            transform.Translate(new Vector2(-flySpeed * Time.deltaTime, 0));

        if (Random.Range(0f, 1f) <= eatChance * Time.deltaTime && currentState == CrowState.Idle)
        {
            ChangeState(CrowState.Eating);
            Invoke("DefaultState", 0.933f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ChangeState(CrowState.Flying);
            FlyAway(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "CrowZone" && currentState == CrowState.Flying)
            Destroy(gameObject);
    }

    public void ChangeState(int state)
    {
        currentState = state;
        animator.SetInteger("State", currentState);
    }

    public void DefaultState()
    {
        ChangeState(CrowState.Idle);
    }

    public void FlyAway(Transform target)
    {
        transform.right = target.position - transform.position;
        spriteRenderer.flipY = transform.rotation.eulerAngles.z <= 270 && transform.rotation.eulerAngles.z >= 90;
    }
}

public static class CrowState
{
    public const int Idle = 0;
    public const int Flying = 1;
    public const int Eating = 2;
}