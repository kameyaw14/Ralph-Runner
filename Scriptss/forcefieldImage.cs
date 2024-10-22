using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefieldImage : MonoBehaviour
{
 

    private ralphMovement ralphMovementScript;
    [SerializeField] private GameObject shieldPrefab;
    private GameObject shieldInstance;

    [SerializeField] private float shieldedTime;

    private void Start()
    {
        ralphMovementScript = FindObjectOfType<ralphMovement>();
        Debug.Log("Force field script started. Shield Prefab: " + (shieldPrefab != null ? "Assigned" : "Not assigned"));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ralphMovement playerMovement = other.GetComponent<ralphMovement>();
            if (playerMovement != null && !playerMovement.shielded)
            {
                if (shieldInstance == null)
                {
                    shieldInstance = Instantiate(shieldPrefab, other.transform.position, Quaternion.identity, other.transform);
                }
                else
                {
                    shieldInstance.SetActive(true);
                }

                Debug.Log("Shield activated");
                playerMovement.shielded = true;
                Invoke("NoShield", shieldedTime);
                Debug.Log("Player collided with the forcefield");
            }
        }
    }

    public void NoShield()
    {
        if (ralphMovementScript != null && shieldInstance != null)
        {
            shieldInstance.SetActive(false);
            Debug.Log("Shield deactivated");
            ralphMovementScript.shielded = false;
        }
    }


}
