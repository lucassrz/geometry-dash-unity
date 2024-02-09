using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    public Transform ToFollow;
    
    void Update()
    {
        transform.position = new Vector3 (ToFollow.position.x + 6, 0, -10);
    }
}
