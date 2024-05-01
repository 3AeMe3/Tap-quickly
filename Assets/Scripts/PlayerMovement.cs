using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float speed;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;
    AudioSource audioSource;
    [SerializeField] AudioClip changeDirectionSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if(GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            animator.SetBool("isRun", true);
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(changeDirectionSound);
                speed = -speed;
            }
            if (speed < 0)
            {

                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;

            }
        }
        else
        {
            animator.SetBool("isRun", false);

        }



    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            rb.velocity = Vector2.right * speed;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Wall"))
            {
                speed = -speed;
            }
        
    }
            


}
