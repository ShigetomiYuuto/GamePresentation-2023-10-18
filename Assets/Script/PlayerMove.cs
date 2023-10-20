using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower;
    [SerializeField] Vector3 _moveInput;
    Rigidbody _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        _rb.velocity = new Vector3(_moveInput.x * _movePower, _rb.velocity.y , _moveInput.y * _movePower);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector3>();
    }
}
