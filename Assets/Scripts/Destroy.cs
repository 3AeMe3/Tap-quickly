using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] Score score;

    private const string daikonTag = "Daikon";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(daikonTag))
        {
            score.RestPoints();
        }

        Destroy(collision.gameObject);
    }

}
