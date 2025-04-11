using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private PlayerConfig _playerConfig;

    private Vector2 _moveDirection;
    private Vector2 _moveVelocity;

    private bool _isFacingRight;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _isFacingRight = true;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FlipCheck();
    }

    private void FixedUpdate()
    {
        MoveInternal();
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
       
        if (_moveDirection != Vector2.zero)
        {
            var targetVelocity = Vector2.zero;
            targetVelocity = _moveDirection * _playerConfig.speed;

            _moveVelocity = Vector2.Lerp(_moveVelocity, targetVelocity, _playerConfig.acceleration * Time.fixedDeltaTime);
            _rb.linearVelocity = new Vector2(_moveVelocity.x, _rb.linearVelocity.y);
        }
        else if(_moveDirection == Vector2.zero)
        {
            _moveVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, _playerConfig.deceleration * Time.fixedDeltaTime);
            _rb.linearVelocity = new Vector2(_moveVelocity.x, _rb.linearVelocity.y);
        }
    }

    private void FlipCheck()
    {
        if (_isFacingRight && _moveDirection.x < 0)
        {
            Flip(false);
        }

        else if (!_isFacingRight && _moveDirection.x > 0)
        {
            Flip(true);
        }
    }

    private void Flip(bool flipRight)
    {
        if (flipRight)
        {
            _isFacingRight = true;
            transform.Rotate(0, 180f, 0);
        }
        else
        {
            _isFacingRight = false;
            transform.Rotate(0, -180f, 0);
        }
    }
}
