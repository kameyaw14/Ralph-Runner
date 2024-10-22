using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawDamage : MonoBehaviour
{
    [SerializeField] private float damageReduction = 3;

    

   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
           
            collision.GetComponent<HealthScript>().TakeDamage(damageReduction);
        }
    }
}
