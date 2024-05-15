using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField]ThrowItems throwItems;
    [SerializeField]TextMeshProUGUI textMeshProUGUI;
    public int score;
    [SerializeField] AudioClip grabSound;
    AudioSource audioSource;

    [SerializeField] GameObject GameOverPanel;


    private void Awake()
    {
     
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 10;
        textMeshProUGUI.text = score.ToString();
    }
    public void RestPoints()
    {
        score -= 2;
        textMeshProUGUI.text = score.ToString();

    }

    private void Update()
    {
        GameOver();
    }
    void GameOver()
    {
        if(score <= 0)
        {
            //Game over 
            gameManager.currentState = GameState.GameOver;
            GameOverPanel.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Daikon"))
        {
            score++;
            textMeshProUGUI.text = score.ToString();
            audioSource.PlayOneShot(grabSound,1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            score -= 3;
            textMeshProUGUI.text = score.ToString();
            audioSource.PlayOneShot(grabSound,1);

            Destroy(collision.gameObject);

        }
    }

  
}
