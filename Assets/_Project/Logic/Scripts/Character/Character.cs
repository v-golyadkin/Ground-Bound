using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private PlayerConfig _playerConfig;

    private Vector2 _moveDirection;
    private Vector2 _moveVelocity;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        if(_moveDirection != Vector2.zero)
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
}
