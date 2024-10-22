
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickups : MonoBehaviour
{
    [SerializeField] private float healthAmount = 20f; // Amount of health to restore

    [SerializeField] private AudioClip healthSound;

    


   
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the pickup
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(healthSound);
            HealthScript playerHealth = other.GetComponent<HealthScript>();

            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healthAmount);
                Destroy(gameObject); // Destroy the health pickup
            }
        }
    }
}