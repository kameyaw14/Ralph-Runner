
//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using UnityEngine;

//public class HealthScript : MonoBehaviour
//{
//    [SerializeField] private float startHealth = 1;
//    public float currHealth { get; private set; }

//    [SerializeField] private GameManagerScript gameManager;
//    private bool isDead;

//    private void Awake()
//    {
//        currHealth = startHealth;
//    }

//    public void TakeDamage(float _damage)
//    {
//        currHealth = Mathf.Clamp(currHealth - _damage, 0, startHealth);

//        if (currHealth > 0 && !isDead)
//        {
//            //hurt
//        }
//        else
//        {
//            //dead
//            //Destroy(gameObject);

//            isDead = true;
//            gameManager.GameOver();
//        }
//    }

//    public void RestoreHealth(float amount)
//    {
//        currHealth = Mathf.Clamp(currHealth + amount, 0, startHealth);
//        Debug.Log("Health restored: " + currHealth);
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float startHealth = 1;
    public float currHealth { get; private set; }

    [SerializeField] private GameManagerScript gameManager;
    private bool isDead;

    private void Awake()
    {
        currHealth = startHealth;
    }

    public void TakeDamage(float _damage)
    {
        if (!GetComponent<ralphMovement>().IsShielded()) // Check if shielded
        {
            currHealth = Mathf.Clamp(currHealth - _damage, 0, startHealth);

            if (currHealth > 0 && !isDead)
            {
                // Hurt animation or effect
            }
            else
            {
                // Dead animation or effect
                isDead = true;
                gameManager.GameOver();
            }
        }
        else
        {
            // Play shielded effect or animation
        }
    }

    public void RestoreHealth(float amount)
    {
        currHealth = Mathf.Clamp(currHealth + amount, 0, startHealth);
        Debug.Log("Health restored: " + currHealth);
    }
}

