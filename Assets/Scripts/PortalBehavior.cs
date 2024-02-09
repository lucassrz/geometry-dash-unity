using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    public string Type;
    
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>() is PlayerBehavior player) player.ChangeGravity(Type);
    }
}
