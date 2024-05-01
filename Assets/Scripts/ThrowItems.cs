using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ThrowItems : MonoBehaviour
{


    public GameObject[] items;
    [SerializeField] float timeSpawn;
   
    public float timeDelay;

   

    private void Start()
    {
        InvokeRepeating(nameof(InstantiateItems), timeSpawn, timeDelay );
    }
    private void Update()
    {
        
    }
    void InstantiateItems()
    {
        if(GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            int rnd = Random.Range(0, 3);
            Instantiate(items[rnd], transform.position, Quaternion.identity);
        }
  
    }

}
