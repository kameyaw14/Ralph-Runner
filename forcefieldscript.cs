using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefieldscript : MonoBehaviour
{
    private ralphMovement ralphMovementScript;
    //[SerializeField] private GameObject shield;

    [SerializeField] private float shieldTime;



    private void Start()
    {
        ralphMovementScript = FindObjectOfType<ralphMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the pickup
        if (other.CompareTag("Player"))
        {
            ralphMovement playerMovement = other.GetComponent<ralphMovement>();

            //if (bool1 = true)
           
                {
                    if (playerMovement != null && !playerMovement.shielded)
                    {
                        //shield.SetActive(true);
                        playerMovement.shielded = true;
                        Invoke("NoShield", shieldTime);
                        Debug.Log("Player collided with the forcefield");
                    }
                }
           
           
        }
    }

    public void NoShield()
    {
        if (ralphMovementScript != null)
        {
            //shield.SetActive(false);
            ralphMovementScript.shielded = false;
        }
    }
}
