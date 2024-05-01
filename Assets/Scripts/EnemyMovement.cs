using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            rb.velocity = speed * Vector2.left;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                speed = -speed;
                spriteRenderer.flipX = !spriteRenderer.flipX;

            }
        }
       
    }

}
