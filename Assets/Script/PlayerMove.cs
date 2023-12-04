using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _movePower;
    [SerializeField] float _jumpPower;
    [SerializeField] Vector3 _moveInput;
    [SerializeField] bool _isGround = false;
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
        // 入力された方向を「カメラを基準とした XZ 平面上のベクトル」に変換する
        Vector3 _dir = Vector3.forward * _moveInput.y + Vector3.right * _moveInput.x;
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;

        // キャラクターを「入力された方向」に向ける
        if (_dir != Vector3.zero)
        {
            this.transform.forward = _dir;
        }

        _rb.velocity = new Vector3(_moveInput.x * _movePower, _rb.velocity.y, _moveInput.y * _movePower);
        Vector3 velocity = _dir.normalized * _movePower;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector3>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && _isGround)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpPower, _rb.velocity.z);
            _isGround = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
}
