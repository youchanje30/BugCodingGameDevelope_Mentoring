using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 필요 컴포넌트
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _playerInput;

    // 점프와 중력 관련 변수
    private float gravityScale = 4f;
    private float slideGravityScale = 8f;
    private bool _isHolding = false;

    // 플레이어 참조
    [SerializeField] private Player _player;

    private void Awake()
    {
        ConnectPlayerInput();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Idle();
    }

    private void ConnectPlayerInput()
    {
        _playerInput = new PlayerInput();

        _playerInput.Movement.Jump.started   += ctx => { if (_player.IsGrounded()) { Jump(); _isHolding = true; StartCoroutine(HoldJump()); } };
        _playerInput.Movement.Jump.canceled  += ctx => _isHolding = false;

        _playerInput.Movement.Slide.performed += ctx => Slide();
        _playerInput.Movement.Slide.canceled  += ctx => Idle();

        _playerInput.Movement.Enable();
    }

    private void Jump()
    {
        if (!_player.IsGrounded()) return;
        _player.SetJump();
        _rigidbody2D.AddForce(Vector2.up * _player.jumpForce, ForceMode2D.Impulse);
    }

    private IEnumerator HoldJump()
    {
        for (float timer = 0; timer < 0.3f && _isHolding; timer += Time.deltaTime)
        {
            _rigidbody2D.AddForce(Vector2.up * (_player.highJumpForce * Time.deltaTime), ForceMode2D.Impulse);
            yield return null;
        }

        while (!_player.IsGrounded() || _rigidbody2D.linearVelocityY > 0)
        {
            yield return null;
        }
        Idle();
    }

    private void Slide()
    {
        _player.SetSlide();
        _isHolding = false;
        _rigidbody2D.linearVelocityY = 0f;
        _rigidbody2D.gravityScale = slideGravityScale;
    }

    private void Idle()
    {
        _player.SetIdle();
        _rigidbody2D.gravityScale = gravityScale;
    }
}
