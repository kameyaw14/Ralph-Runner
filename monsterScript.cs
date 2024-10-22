using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScript : MonoBehaviour
{
    [SerializeField] private AudioClip monsterSound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fireball"))
        {
            AudioManager.instance.PlaySound(monsterSound);
        }
    }
}
