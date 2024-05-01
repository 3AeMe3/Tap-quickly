using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forceThrow;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
     rb.AddForce(Vector2.up * forceThrow,ForceMode2D.Impulse);   
    }



}
