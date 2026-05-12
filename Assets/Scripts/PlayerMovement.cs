using UnityEngine;
using UnityEngine.InputSystem; // Necessário para o sistema novo

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    public float _moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _rb.freezeRotation = true;
    }


    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * _moveSpeed;
    }
}