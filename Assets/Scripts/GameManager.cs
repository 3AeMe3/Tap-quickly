using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Start, InGame, GameOver }
public class GameManager : MonoBehaviour
{
  
    [SerializeField] Score score;



    
    public GameState currentState;


    [SerializeField] GameObject menuManager;
    [SerializeField] GameObject enemyPrefab;
    bool hasInstantiateEnemy;

    [SerializeField] AudioClip spawnEnemy;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    
    }

    private void Start()
    {
        currentState = GameState.Start;
    }
    private void Update()
    {



        if (currentState == GameState.InGame)
        {
            if (score.score == 15 && !hasInstantiateEnemy)
            {

                Instantiate(enemyPrefab, new Vector2(transform.position.x, 2.55f), Quaternion.identity);
                hasInstantiateEnemy = true;
                audioSource.PlayOneShot(spawnEnemy, 0.5f);
            }

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = GameState.Start;
            menuManager.SetActive(true);

        }

        
      
        
    }
    public void ContinueGame()
    {
        currentState = GameState.InGame;
        menuManager.SetActive(false);

    }

    public void RealoadGame()
    {
     
        SceneManager.LoadScene(0);

    }
    public void ExitGame()
    {
        //cerrar el juego
    }
}
