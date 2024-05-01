using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Score score;
    
    

    public enum GameState { Start,InGame, GameOver }
    public GameState currentState;


    [SerializeField] GameObject menuManager;
    [SerializeField] GameObject enemyPrefab;
    bool hasInstantiateEnemy;

    [SerializeField] AudioClip spawnEnemy;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentState = GameState.Start;
    }
    private void Update()
    {

        
       
        if (score.score == 15 && !hasInstantiateEnemy)
        {
            
            Instantiate(enemyPrefab, new Vector2(transform.position.x,2.55f), Quaternion.identity);
            hasInstantiateEnemy = true;
            audioSource.PlayOneShot(spawnEnemy,0.5f);
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
    public void ExitGame()
    {
        //cerrar el juego
    }
}
