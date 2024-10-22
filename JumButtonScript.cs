using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for IPointerDownHandler

public class JumButtonScript : MonoBehaviour, IPointerDownHandler
{
    // Reference to the ralphMovement script
    public ralphMovement ralphMovementScript;

    // This method is called when the button is pressed down
    public void OnPointerDown(PointerEventData eventData)
    {
        // Call the Jump method from the ralphMovement script
        ralphMovementScript.Jump();
    }
}
