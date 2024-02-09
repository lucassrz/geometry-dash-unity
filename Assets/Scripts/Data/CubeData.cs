using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game/Character")]
public class CubeData : ScriptableObject
{
    public Sprite DefaultSprite;
    public int JumpForce;
    public float Speed;
    public int Gravity;
}
