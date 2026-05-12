using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float _moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    
    
    public int multiplicadorDirecao = 1; 
    public float multiplicadorVelocidade = 1f; 

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
        
        _rb.linearVelocity = _moveInput * (_moveSpeed * multiplicadorVelocidade) * multiplicadorDirecao;
    }
}