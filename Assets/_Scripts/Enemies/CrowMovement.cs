using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float flySpeed = 5;
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

    public void FlyAway(Transform target)
    {
        transform.right = target.position - transform.position;
        spriteRenderer.flipY = transform.rotation.eulerAngles.z <= 270;
        Debug.Log(transform.rotation.eulerAngles);
    }
}

public static class CrowState
{
    public const int Idle = 0;
    public const int Flying = 1;
    public const int Eating = 2;
}