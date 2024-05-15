using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField] Sprite[] sprites;

    [SerializeField] float timeFrame;
    int frameCurrent;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }
    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindAnyObjectByType<GameManager>();
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(Animation), timeFrame, timeFrame);
    }
    void Animation()
    {
        if(gameManager.currentState == GameState.InGame)
        {
            frameCurrent++;
            if (frameCurrent >= sprites.Length)
            {
                frameCurrent = 0;
            }
            spriteRenderer.sprite = sprites[frameCurrent];
        }

    }

}
