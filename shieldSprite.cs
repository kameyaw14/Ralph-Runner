using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldSprite : MonoBehaviour
{
    [SerializeField] private AudioClip shieldImageSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fireball"))
        {
            AudioManager.instance.PlaySound(shieldImageSound);
        }
    }
}
