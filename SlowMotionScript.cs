


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionScript : MonoBehaviour
{
    [SerializeField] private float slowTimeScale = 0.5f; // Time scale when slow motion is active
    [SerializeField] private float slowDuration = 2f; // Duration of the slow motion effect in seconds

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fireball"))
        {
            StartCoroutine(ApplySlowMotion());
        }
    }

    private IEnumerator ApplySlowMotion()
    {
        Time.timeScale = slowTimeScale; // Slow down time
        yield return new WaitForSecondsRealtime(slowDuration); // Wait for the slow duration in real-time seconds
        Time.timeScale = 1f; // Reset time scale to normal
    }
}
