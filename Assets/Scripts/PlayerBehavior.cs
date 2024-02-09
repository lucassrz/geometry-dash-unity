using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _lastJump;
    private string GravityType;
    private float maxSpeed = 0f;
    
    public CubeData Cube;
    public SpriteRenderer Sprite;
    
    private float speed;
    Vector3 oldPosition;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        Sprite.sprite = Cube.DefaultSprite;
        _isGrounded = false;
    }
    
    private void OnValidate()
    {
        Sprite.sprite = Cube.DefaultSprite;
    }
    
    void FixedUpdate()
    {
        //_rb.velocity = new Vector2(Cube.Speed, _rb.velocity.y);
        _rb.position += Vector2.right * 0.24f;
        maxSpeed = _rb.velocity.y > maxSpeed ? _rb.velocity.y : maxSpeed;
        if (maxSpeed > Cube.Speed) CheckSpeed();
        InputKey();
        ApplyGravity();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) _isGrounded = true;
    }
    
    void OnCollisionExit2D()
    {
        _isGrounded = false;
    }
    
    private void InputKey()
    {
        if ((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.Mouse0)) && _isGrounded && 0.05 < Time.time - _lastJump) Jump();
        
        if (Input.GetKey(KeyCode.R)) Retry();
        
        if (Input.GetKey(KeyCode.Escape)) MenuManager.LevelListButton();
    }

    public void Jump()
    {
        _lastJump = Time.time;
        _rb.AddForce(GetJumpAxe() * Cube.JumpForce);
        //Sprite.Rotate(Vector3.back, 452.4152186f * Time.deltaTime * _rb.gravityScale);
    }

    public void BigJump()
    {
        _lastJump = Time.time;
        _rb.AddForce(GetJumpAxe() * Cube.JumpForce * 1.5f);
        //Sprite.Rotate(Vector3.back, 452.4152186f * Time.deltaTime * _rb.gravityScale);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ApplyGravity()
    {
        if (GravityType == "bottom") _rb.gravityScale = Cube.Gravity;
        else if (GravityType == "top") _rb.gravityScale = -Cube.Gravity;
        else if (GravityType == "none") _rb.gravityScale = 0;
        else _rb.gravityScale = Cube.Gravity;
    }

    public void ChangeGravity(string type)
    {
        GravityType = type;
    }

    private Vector2 GetJumpAxe()
    {
        if (GravityType == "top") return Vector2.down;
        return Vector2.up;
    }

    private void CheckSpeed()
    {
        speed = Vector3.Distance (oldPosition, transform.position);
        oldPosition = transform.position;
        if (speed <= 0.10f) Retry();
    }
}
