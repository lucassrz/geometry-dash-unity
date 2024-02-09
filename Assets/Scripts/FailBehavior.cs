using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailBehavior : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>() is PlayerBehavior player) player.Retry();
    }
}
