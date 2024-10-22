

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public GameObject effect;
    [SerializeField] private float damageReduction = 1;

    private shake cameraShake;

    [SerializeField] private AudioClip fireballSound;
    [SerializeField] private AudioClip hitSound;

    private void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("ShakeTag").GetComponent<shake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ralphMovement playerMovement = collision.GetComponent<ralphMovement>();
            if (playerMovement != null && playerMovement.IsShielded())
            {
                Debug.Log("Player is shielded, no damage applied");
                return;
            }

            cameraShake.ShakeFunction();
            Instantiate(effect, transform.position, Quaternion.identity);

            AudioManager.instance.PlaySound(hitSound);



            HealthScript healthScript = collision.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(damageReduction);
                Debug.Log("Collided and damage applied");
            }

            Destroy(gameObject);

        }
        if (collision.CompareTag("saw"))
        {
            cameraShake.ShakeFunction();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("ForceFieldTag"))
        {
            cameraShake.ShakeFunction();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("fireballAudio"))
        {
            AudioManager.instance.PlaySound(fireballSound);
        }
    }
}
