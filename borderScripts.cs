using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderScripts : MonoBehaviour
{
    [SerializeField] private float sideshootSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.Translate(Vector2.left * sideshootSpeed * Time.deltaTime);
            Debug.Log("Shot");

         
        }

        if (collision.CompareTag("ForceFieldTag"))
        {
            transform.Translate(Vector2.left * sideshootSpeed * Time.deltaTime);
            Debug.Log("Shot");


        }
    }




}
