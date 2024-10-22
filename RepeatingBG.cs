using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RepeatingBG : MonoBehaviour
{
    public float bgSpeed;

    public float startX;
    public float endX;

    private void Update()
    {
        transform.Translate(Vector2.left * bgSpeed * Time.deltaTime);

        if(transform.position.x <= endX)
        {
            Vector2 pos = new Vector2 (startX, transform.position.y);
            transform.position = pos;
        }
    }
}
