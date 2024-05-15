using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ThrowItems : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public GameObject[] items;
    [SerializeField] float timeSpawn;
   
    public float timeDelay;

   

    private void Start()
    {
        InvokeRepeating(nameof(InstantiateItems), timeSpawn, timeDelay );
    }
    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindAnyObjectByType<GameManager>();
        }
    }
    void InstantiateItems()
    {   
        if(gameManager.currentState == GameState.InGame)
        {
            int rnd = Random.Range(0, 3);
            Instantiate(items[rnd], transform.position, Quaternion.identity);
        }
  
    }

}
