using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float attackTime;

    private bool isJumping = false;
    private bool isAttacking = false;

    private Rigidbody2D rb;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            Debug.Log("jump");
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Attack();
        }
    }

    private void Attack()
    {
        StartCoroutine(att());
    }

    private IEnumerator att()
    {
        isAttacking = true;
        animator.SetBool("attack", true);

        rb.velocity= Vector2.zero;
        rb.gravityScale = 0f;

        yield return new WaitForSeconds(attackTime);
        animator.SetBool("attack", false);
        rb.gravityScale = 1f;
        isAttacking=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game over");
        Destroy(gameObject);
    }
}
