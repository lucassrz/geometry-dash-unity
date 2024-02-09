using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceJumpBehavior : MonoBehaviour
{
    public enum JumpListe{
        normal,
        big,
    }
    
    public JumpListe jumpType;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>() is PlayerBehavior player)
        {
            if (jumpType == JumpListe.big) player.BigJump();
            else if (jumpType == JumpListe.normal) player.Jump();
        }
    }
}
