using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
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
        if (gameManager == null)
        {
            gameManager = GameObject.FindAnyObjectByType<GameManager>();
        }

        if (gameManager.currentState == GameState.InGame)
        {
            rb.velocity = speed * Vector2.left;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager.currentState == GameState.InGame)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                speed = -speed;
                spriteRenderer.flipX = !spriteRenderer.flipX;

            }
        }
       
    }

}
