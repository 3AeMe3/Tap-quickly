using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]ThrowItems throwItems;
    [SerializeField]TextMeshProUGUI textMeshProUGUI;
    public int score;
    [SerializeField] AudioClip grabSound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 0;
        textMeshProUGUI.text = score.ToString();
    }
    private void Update()
    {
        
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
